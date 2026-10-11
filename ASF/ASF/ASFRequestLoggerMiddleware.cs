using System;
using System.Net;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASF;

/// <summary>
///   日志拦截中间件
/// </summary>
public class ASFRequestLoggerMiddleware
{
  private readonly RequestDelegate _next;

  /// <summary>
  ///   日志拦截中间件
  /// </summary>
  /// <param name="next"></param>
  public ASFRequestLoggerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  /// <summary>
  ///   日志事件
  /// </summary>
  /// <param name="context"></param>
  /// <returns></returns>
  public async Task InvokeAsync(HttpContext context)
  {
    var requestPath = context.Request.PathBase + context.Request.Path;
    if (requestPath.Value != null && requestPath.Value.Equals("/swagger/v1/swagger.json"))
    {
      await _next(context);
      return;
    }

    var serviceProvider = context.RequestServices;
    var logger = serviceProvider.GetRequiredService<ILogger<ASFRequestLoggerMiddleware>>();
    try
    {
      if (context.Items.ContainsKey("asf_api_parmission") &&
          context.Items["asf_api_parmission"] is Api api)
      {
        if (api.IsLogger != null && (Status)api.IsLogger == Status.Yes)
          await ASFRequestLogger.GetInstance(context, _next).Record(api);
        else
          await _next(context);
      }
      else
      {
        await _next(context);
      }
    }
    catch (Exception ex)
    {
      logger.LogError(ex, "ASF Logging");
      if (!context.Response.HasStarted)
        await _next(context);
    }
  }
}
