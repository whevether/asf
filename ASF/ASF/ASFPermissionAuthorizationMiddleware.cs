using System.Net;
using System.Threading.Tasks;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ASF;

/// <summary>
///   api 鉴权中间件
/// </summary>
public class ASFPermissionAuthorizationMiddleware
{
  private readonly RequestDelegate _next;

  /// <summary>
  ///   api 鉴权中间件
  /// </summary>
  /// <param name="next"></param>
  public ASFPermissionAuthorizationMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  /// <summary>
  ///   中间件事件
  /// </summary>
  /// <param name="httpContext"></param>
  /// <returns></returns>
  public async Task Invoke(HttpContext httpContext)
  {
    var serviceProvider = httpContext.RequestServices;
    var logger = serviceProvider.GetRequiredService<ILogger<ASFPermissionAuthorizationMiddleware>>();
    var requestPath = httpContext.Request.PathBase + httpContext.Request.Path;
    if (requestPath.Value != null &&
        (requestPath.Value.Contains("swagger") || requestPath.Value.Contains("assets") || requestPath.Value.Equals("/favicon.ico")))
    {
      await _next(httpContext);
    }
    else
    {
      //验证登陆用户是否有权限
      var result = await serviceProvider.GetRequiredService<AccountAuthorizationService>().Authentication();

      if (result.Success)
      {
        if (result.Data.IsLogger != null && (Status)result.Data.IsLogger == Status.Yes)
          logger.LogInformation($"{requestPath} Permission authorization success");

        httpContext.Items.Add("asf_api_parmission", result.Data);
        await _next(httpContext);
      }
      else
      {
        var statusCode = httpContext.User.Identity != null && !httpContext.User.Identity.IsAuthenticated ? 401 : 403;
        httpContext.Response.StatusCode = statusCode;
        httpContext.Response.ContentType = "application/json;charset=utf-8";
        var body = AsfJson.Serialize(new { status = statusCode, result = (object)null, message = result.Message });
        await httpContext.Response.WriteAsync(body);
        logger.LogWarning(
          $"{requestPath} Response.StatusCode {statusCode} Permission authorization failed ");
      }
    }
  }
}
