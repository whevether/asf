using System;
using System.Threading.Tasks;
using ASF.Internal.Json;
using ASF.Internal.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ASF.DependencyInjection;

/// <summary>
///   统一全局错误拦截
/// </summary>
public class ErrorHandlingMiddleware
{
  private readonly ILogger<ErrorHandlingMiddleware> _logger;
  private readonly RequestDelegate _next;

  /// <summary>
  ///   统一错误处理中间件
  /// </summary>
  public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
  {
    _next = next;
    _logger = logger;
  }

  /// <summary>
  ///   激活
  /// </summary>
  /// <param name="context"></param>
  /// <returns></returns>
  public async Task Invoke(HttpContext context)
  {
    try
    {
      await _next(context);
      if (context.Response.HasStarted)
        return;

      var statusCode = context.Response.StatusCode;
      var msg = statusCode switch
      {
        404 => ResultMessage.Localize("serviceNotFound"),
        502 => ResultMessage.Localize("badGateway"),
        _ => ""
      };
      if (!string.IsNullOrWhiteSpace(msg))
        await WriteJsonAsync(context, statusCode, msg);
    }
    catch (Exception ex)
    {
      _logger.LogError(ex, "统一拦截异常处理");
      if (context.Response.HasStarted)
        return;

      var statusCode = ex is ArgumentException ? 200 : 500;
      try
      {
        await ASFRequestLogger.GetInstance(context, _next).Record("异常消息", ex.Message);
      }
      catch
      {
        // ignore logging failures
      }

      await WriteJsonAsync(context, statusCode, ResultMessage.Localize("internalServerError"));
    }
  }

  private static Task WriteJsonAsync(HttpContext context, int statusCode, string msg)
  {
    if (context.Response.HasStarted)
      return Task.CompletedTask;

    var result = AsfJson.Serialize(new { status = statusCode, result = (object)null, message = msg });
    context.Response.StatusCode = statusCode;
    context.Response.ContentType = "application/json;charset=utf-8";
    return context.Response.WriteAsync(result);
  }
}
