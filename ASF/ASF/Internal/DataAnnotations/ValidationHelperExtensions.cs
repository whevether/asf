using System.Text.RegularExpressions;

namespace System;

/// <summary>
///   验证帮助根据扩展类
/// </summary>
public static class ValidationHelperExtensions
{
    /// <summary>
    ///   验证域名格式
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsDomainUrl(this string value)
  {
    var _regex = @"^[a-zA-Z0-9][-a-zA-Z0-9]{0,62}(\.[a-zA-Z0-9][-a-zA-Z0-9]{0,62})+$";
    var reg = new Regex(_regex);
    if (!reg.IsMatch(value))
    {
      if (value == "localhost")
        return true;
      return false;
    }

    return true;
  }

    /// <summary>
    ///   验证URL格式
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsUrl(this string value)
  {
    var _regex =
      @"^((http|ftp|https)://)(([a-zA-Z0-9\._-]+\.[a-zA-Z]{2,6})|([0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}))(:[0-9]{1,4})*(/[a-zA-Z0-9\&%_\./-~-]*)?$";
    var reg = new Regex(_regex);
    if (!reg.IsMatch(value))
      return false;
    return true;
  }
}