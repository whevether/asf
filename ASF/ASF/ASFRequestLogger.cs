﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ASF;

/// <summary>
///   处理日志请求
/// </summary>
public class ASFRequestLogger
{
  private readonly RequestDelegate _next;

  private readonly HttpContext httpContext;

  private readonly IServiceProvider serviceProvider;

  private ASFRequestLogger(HttpContext context, RequestDelegate next)
  {
    httpContext = context;
    serviceProvider = httpContext.RequestServices;
    _next = next;
  }

  /// <summary>
  ///   日志请求安全单例模式
  /// </summary>
  /// <param name="context"></param>
  /// <param name="next"></param>
  /// <returns></returns>
  public static ASFRequestLogger GetInstance(HttpContext context, RequestDelegate next)
  {
    return new ASFRequestLogger(context, next);
  }

  /// <summary>
  ///   记录日志
  /// </summary>
  public async Task Record(Api api)
  {
    var request = httpContext.Request;
    var requestContent = "";
    var responseContent = "";
    //
    // // 获取请求body内容
    if (request.Method.ToLower().Equals("post"))
    {
      // 启用倒带功能，就可以让 Request.Body 可以再次读取
      //request.EnableRewind();//2.0版使用这个
      request.EnableBuffering(); //3.1版使用这个方法

      var stream = request.Body;
      if (request.ContentLength != null)
      {
        var buffer = new byte[request.ContentLength.Value];
        await stream.ReadExactlyAsync(buffer);
        requestContent = Encoding.UTF8.GetString(buffer);
      }

      request.Body.Position = 0;
    }
    else if (request.Method.ToLower().Equals("get"))
    {
      requestContent = request.QueryString.Value;
    }

    // 获取Response.Body内容
    var originalBodyStream = httpContext.Response.Body;

    using (var responseBody = new MemoryStream())
    {
      httpContext.Response.Body = responseBody;

      await _next(httpContext);

      responseContent = await GetResponse(httpContext.Response);

      await responseBody.CopyToAsync(originalBodyStream);
    }

    // var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    var logInfo = new LogInfo
    {
      Remark = "操作记录"
    };
    logInfo.SetOperate(httpContext.User.UserId(), httpContext.User.Name(), api.Name, LoggingType.Operate,
      api.PermissionId, httpContext.Request.Path.Value, requestContent,
      httpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1", responseContent);
    await serviceProvider.GetRequiredService<LoggerService>().Create(logInfo);
    //
    // _recordLogService.Record(permission, requestContent, responseContent);
    // await _unitOfWork.CommitAsync(autoRollback: true);
    // return;
    await Task.CompletedTask;
  }

  /// <summary>
  ///   记录日志
  /// </summary>
  public async Task Record(string title, string errorMsg)
  {
    var request = httpContext.Request;
    var requestContent = "";
    //
    // // 获取请求body内容
    if (request.Method.ToLower().Equals("post"))
    {
      // 启用倒带功能，就可以让 Request.Body 可以再次读取
      //request.EnableRewind();//2.0版使用这个
      request.EnableBuffering(); //3.1版使用这个方法

      var stream = request.Body;
      if (request.ContentLength != null)
      {
        var buffer = new byte[request.ContentLength.Value];
        await stream.ReadExactlyAsync(buffer);
        requestContent = Encoding.UTF8.GetString(buffer);
      }

      request.Body.Position = 0;
    }
    else if (request.Method.ToLower().Equals("get"))
    {
      requestContent = request.QueryString.Value;
    }

    // var _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
    var logInfo = new LogInfo
    {
      Remark = "操作记录"
    };
    logInfo.SetOperate(httpContext.User.UserId(), httpContext.User.Name(), title, LoggingType.Error, null,
      httpContext.Request.Path.Value, requestContent, httpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1",
      errorMsg);
    await serviceProvider.GetRequiredService<LoggerService>().Create(logInfo);
    //
    // _recordLogService.Record(permission, requestContent, responseContent);
    // await _unitOfWork.CommitAsync(autoRollback: true);
    // return;
    await Task.CompletedTask;
  }

  /// <summary>
  ///   获取响应内容
  /// </summary>
  /// <param name="response"></param>
  /// <returns></returns>
  public async Task<string> GetResponse(HttpResponse response)
  {
    response.Body.Seek(0, SeekOrigin.Begin);
    var text = await new StreamReader(response.Body).ReadToEndAsync();
    response.Body.Seek(0, SeekOrigin.Begin);
    return text;
  }
}