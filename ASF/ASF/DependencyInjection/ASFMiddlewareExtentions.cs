using ASF;
using ASF.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.Extensions.DependencyInjection;

/// <summary>
///   使用中间件
/// </summary>
internal static class ASFMiddlewareExtentions
{
  public static IApplicationBuilder UseASFMiddleware(this IApplicationBuilder app)
  {
    #region 做外部请求身份验证

    app.UseAuthentication();
    app.UseAuthorization();

    #endregion

    app.UseMiddleware<ASFPermissionAuthorizationMiddleware>();
    app.UseMiddleware<ASFRequestLoggerMiddleware>();
    app.UseMiddleware<AuthorizationTokenSecurityPolicy>();
    //统一全局错误拦截
    app.UseMiddleware<ErrorHandlingMiddleware>();

    app.Map("/API/ASF", builder =>
    {
      builder.UseRouting();

      #region asf 控制器重的身份验证

      builder.UseAuthentication();
      builder.UseAuthorization();

      #endregion

      builder.UseEndpoints(endPoints => { endPoints.MapControllers(); });
    });
    // swagger
    app.UseSwagger();
    return app;
  }
}