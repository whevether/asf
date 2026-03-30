using System;
using System.Globalization;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace ASF.Internal.Filters;

/// <summary>
///   根据请求头 Accept-Language 设置当前请求的语言文化，用于多语言返回
/// </summary>
public class AcceptLanguageActionFilter : ActionFilterAttribute
{
  /// <summary>
  /// 
  /// </summary>
  /// <param name="context"></param>
  public override void OnActionExecuting(ActionExecutingContext context)
  {
    var requestCultureFeature = context.HttpContext.Features.Get<IRequestCultureFeature>();
    if (requestCultureFeature?.RequestCulture != null)
    {
      var culture = requestCultureFeature.RequestCulture.Culture;
      var uiCulture = requestCultureFeature.RequestCulture.UICulture;
      CultureInfo.CurrentCulture = culture;
      CultureInfo.CurrentUICulture = uiCulture;
    }
    else
    {
      var options = context.HttpContext.RequestServices.GetService(typeof(IOptions<RequestLocalizationOptions>)) as IOptions<RequestLocalizationOptions>;
      var acceptLanguage = context.HttpContext.Request.Headers["Accept-Language"].FirstOrDefault();
      var (culture, uiCulture) = GetCultureFromAcceptLanguage(acceptLanguage, options?.Value);
      CultureInfo.CurrentCulture = culture;
      CultureInfo.CurrentUICulture = uiCulture;
    }

    base.OnActionExecuting(context);
  }

  private static (CultureInfo culture, CultureInfo uiCulture) GetCultureFromAcceptLanguage(string acceptLanguage, RequestLocalizationOptions locOptions)
  {
    var defaultCulture = new CultureInfo("zh-CN");
    var defaultUiCulture = new CultureInfo("zh-CN");

    if (locOptions != null)
    {
      defaultCulture = locOptions.DefaultRequestCulture.Culture;
      defaultUiCulture = locOptions.DefaultRequestCulture.UICulture;
    }

    if (string.IsNullOrWhiteSpace(acceptLanguage))
      return (defaultCulture, defaultUiCulture);

    var requestedCultures = acceptLanguage
      .Split(',')
      .Select(s =>
      {
        var parts = s.Trim().Split(';');
        var name = parts[0].Trim();
        var q = 1.0;
        if (parts.Length > 1 && parts[1].Trim().StartsWith("q="))
          double.TryParse(parts[1].Trim().Substring(2), NumberStyles.Any, CultureInfo.InvariantCulture, out q);
        return (name, q);
      })
      .OrderByDescending(x => x.q)
      .Select(x => x.name)
      .ToList();

    foreach (var requested in requestedCultures)
    {
      if (locOptions?.SupportedCultures != null)
      {
        var match = locOptions.SupportedCultures.FirstOrDefault(c =>
          c.Name.Equals(requested, StringComparison.OrdinalIgnoreCase) ||
          c.Name.StartsWith(requested.Split('-')[0], StringComparison.OrdinalIgnoreCase));
        if (match != null)
          return (match, locOptions.SupportedUICultures?.FirstOrDefault(c => c.Name == match.Name) ?? match);
      }
      try
      {
        var culture = new CultureInfo(requested);
        return (culture, culture);
      }
      catch (CultureNotFoundException)
      {
        if (requested.Length >= 2)
        {
          try
          {
            var twoLetter = requested.Substring(0, 2);
            var culture = new CultureInfo(twoLetter);
            return (culture, culture);
          }
          catch (CultureNotFoundException)
          {
            // ignore
          }
        }
      }
    }

    return (defaultCulture, defaultUiCulture);
  }
}
