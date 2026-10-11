using System;
using ASF.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace ASF.Internal.Results;

/// <summary>
///   按当前请求文化解析 ResultCodes / 中间件提示语
/// </summary>
public static class ResultMessage
{
  private static IServiceProvider _services;

  /// <summary>
  ///   注入根服务，供无 HttpContext 时回退解析本地化
  /// </summary>
  /// <param name="services"></param>
  public static void Configure(IServiceProvider services)
  {
    _services = services;
  }

  /// <summary>
  ///   按当前请求文化解析资源键；非资源键原样返回
  /// </summary>
  /// <param name="key"></param>
  /// <returns></returns>
  public static string Localize(string key)
  {
    if (string.IsNullOrEmpty(key))
      return key;
    if (!IsResourceKey(key))
      return key;

    var localizer = GetLocalizer();
    if (localizer == null)
      return key;

    return localizer[key].Value;
  }

  /// <summary>
  ///   仅字母数字下划线视为资源键，已格式化的句子不再二次查找
  /// </summary>
  private static bool IsResourceKey(string s)
  {
    foreach (var c in s)
      if (!(char.IsLetterOrDigit(c) || c == '_' || c == '.' || c == '-'))
        return false;
    return true;
  }

  /// <summary>
  ///   本地化后按 string.Format 填充占位符
  /// </summary>
  /// <param name="key"></param>
  /// <param name="args"></param>
  /// <returns></returns>
  public static string Format(string key, params object[] args)
  {
    var text = Localize(key);
    if (args == null || args.Length == 0)
      return text;
    try
    {
      return string.Format(text, args);
    }
    catch (FormatException)
    {
      return text;
    }
  }

  private static IStringLocalizer<SharedResource> GetLocalizer()
  {
    try
    {
      var http = _services?.GetService<IHttpContextAccessor>();
      var sp = http?.HttpContext?.RequestServices ?? _services;
      return sp?.GetService<IStringLocalizer<SharedResource>>();
    }
    catch
    {
      return null;
    }
  }
}
