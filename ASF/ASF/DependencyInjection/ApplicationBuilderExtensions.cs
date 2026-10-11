using System.Net;
using System.Threading.Tasks;
using ASF.Internal.Results;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Builder;

/// <summary>
///   asf 中间件扩展
/// </summary>
public static class ApplicationBuilderExtensions
{
    /// <summary>
    ///   asf 中间件
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    public static IApplicationBuilder UseASF(this IApplicationBuilder app)
  {
    ResultMessage.Configure(app.ApplicationServices);
    var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
    app.UseRequestLocalization(locOptions.Value);
    // Nginx 代理时获取真实 IP
    app.Use(async (context, next) =>
    {
      var headers = context.Request.Headers;
      if (headers.ContainsKey("X-Forwarded-For"))
      {
        var forwarded = headers["X-Forwarded-For"].ToString().Split(',')[0].Trim();
        if (IPAddress.TryParse(forwarded, out var ip))
          context.Connection.RemoteIpAddress = ip;
      }

      await next();
    });
    return app.UseASFMiddleware();
  }
}
