using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASF.Domain.Values;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace ASF.Internal.Security;

/// <summary>
///   辅助方法
/// </summary>
public static class Helper
{
  /// <summary>
  ///   淘宝api 通过ip 获取地址
  /// </summary>
  /// <param name="strIP"></param>
  /// <returns></returns>
  public static IpConvertValue GetIpCitys(string strIP)
  {
    try
    {
      var Url = "http://ip-api.com/json/" + strIP;

#pragma warning disable SYSLIB0014
      var wReq = WebRequest.Create(Url);
#pragma warning restore SYSLIB0014
      wReq.Timeout = 15000;
      var wResp = wReq.GetResponse();
      var respStream = wResp.GetResponseStream();
      using (var reader = new StreamReader(respStream))
      {
        var jsonText = reader.ReadToEnd();
        var ja = jsonText.ReadToObject<IpConvertValue>();
        if (ja.Status == "success")
          // ja["data"]["country"].ToString()+ja["data"]["region"].ToString()+ja["data"]["city"].ToString()
          // string c = $"{ja["country"]?.ToString()},{ja["regionName"]?.ToString()},{ja["city"]?.ToString()}";
          // int ci = c.IndexOf('市');
          // if (ci != -1)
          // {
          //     c = c.Remove(ci, 1);
          // }
          return ja;

        return null;
      }
    }
    catch (Exception)
    {
      return null;
    }
  }

  /// <summary>
  ///   生成一个新的 Token
  /// </summary>
  /// <param name="identity">认证信息</param>
  /// <param name="time">过期时间</param>
  /// <returns>表示生成新的Token的任务</returns>
  public static async Task<string> GenerateTokenAsync(ClaimsIdentity identity, long time)
  {
    return await Task.Run(() =>
    {
      var handler = new JwtSecurityTokenHandler();

      // 签发时间
      var issuedAt = DateTime.UtcNow;

      var securityToken = handler.CreateToken(new SecurityTokenDescriptor
      {
        IssuedAt = issuedAt,
        Issuer = "asf",
        Audience = "asf",
        SigningCredentials = new SigningCredentials(RSA.RSAPrivateKey, SecurityAlgorithms.RsaSha256Signature),
        Subject = identity,
        // 到期时间
        Expires = issuedAt.AddSeconds(time)
      });
      return handler.WriteToken(securityToken);
    });
  }

  /// <summary>
  ///   序列化
  /// </summary>
  /// <param name="obj"></param>
  /// <returns></returns>
  public static string WriteFromObject(this object obj)
  {
    var settings = new JsonSerializerSettings
    {
      ContractResolver = new CamelCasePropertyNamesContractResolver()
    };
    var dcjs = JsonConvert.SerializeObject(obj, settings);
    return dcjs;
  }

  /// <summary>
  ///   反序列化
  /// </summary>
  /// <param name="json"></param>
  /// <returns></returns>
  public static JObject ReadToObject(this string json)
  {
    var dcjs = (JObject)JsonConvert.DeserializeObject(json);
    return dcjs;
  }

  /// <summary>
  ///   泛型反序列化
  /// </summary>
  /// <param name="json"></param>
  /// <typeparam name="T"></typeparam>
  /// <returns></returns>
  public static T ReadToObject<T>(this string json) where T : class
  {
    var dcjs = JsonConvert.DeserializeObject<T>(json);
    return dcjs;
  }

  /// <summary>
  ///   字符串转数组
  /// </summary>
  /// <param name="data"></param>
  /// <returns></returns>
  public static List<string> SpitArray(this string data)
  {
    if (string.IsNullOrEmpty(data))
      return new List<string>();
    return data.Split(new[] { ',' }, StringSplitOptions.None).ToList();
  }

  /// <summary>
  ///   隐藏敏感信息
  /// </summary>
  /// <param name="info">信息实体</param>
  /// <param name="left">左边保留的字符数</param>
  /// <param name="right">右边保留的字符数</param>
  /// <param name="basedOnLeft">当长度异常时，是否显示左边 </param>
  /// <returns></returns>
  public static string HideSensitiveInfo(this string info, int left, int right, bool basedOnLeft = true)
  {
    if (string.IsNullOrEmpty(info)) return "";
    var sbText = new StringBuilder();
    var hiddenCharCount = info.Length - left - right;
    if (hiddenCharCount > 0)
    {
      string prefix = info.Substring(0, left), suffix = info.Substring(info.Length - right);
      sbText.Append(prefix);
      for (var i = 0; i < hiddenCharCount; i++) sbText.Append("*");
      sbText.Append(suffix);
    }
    else
    {
      if (basedOnLeft)
      {
        if (info.Length > left && left > 0)
          sbText.Append(info.Substring(0, left) + "****");
        else
          sbText.Append(info.Substring(0, 1) + "****");
      }
      else
      {
        if (info.Length > right && right > 0)
          sbText.Append("****" + info.Substring(info.Length - right));
        else
          sbText.Append("****" + info.Substring(info.Length - 1));
      }
    }

    return sbText.ToString();
  }

  /// <summary>
  ///   隐藏敏感信息
  /// </summary>
  /// <param name="info">信息</param>
  /// <param name="sublen">信息总长与左子串（或右子串）的比例</param>
  /// <param name="basedOnLeft">当长度异常时，是否显示左边，默认true，默认显示左边</param>
  /// <code>true</code>
  /// 显示左边，
  /// <code>false</code>
  /// 显示右边
  /// <returns></returns>
  public static string HideSensitiveInfo(this string info, int sublen = 3, bool basedOnLeft = true)
  {
    if (string.IsNullOrEmpty(info)) return "";
    if (sublen <= 1) sublen = 3;
    var subLength = info.Length / sublen;
    if (subLength > 0 && info.Length > subLength * 2)
    {
      string prefix = info.Substring(0, subLength), suffix = info.Substring(info.Length - subLength);
      return prefix + "****" + suffix;
    }

    if (basedOnLeft)
    {
      var prefix = subLength > 0 ? info.Substring(0, subLength) : info.Substring(0, 1);
      return prefix + "****";
    }

    {
      var suffix = subLength > 0 ? info.Substring(info.Length - subLength) : info.Substring(info.Length - 1);
      return "****" + suffix;
    }
  }

  /// <summary>
  ///   隐藏邮件详情
  /// </summary>
  /// <param name="email">邮件地址</param>
  /// <param name="left">邮件头保留字符个数，默认值设置为3</param>
  /// <returns></returns>
  public static string HideEmailDetails(this string email, int left = 3)
  {
    if (string.IsNullOrEmpty(email)) return "";
    if (Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")) //如果是邮件地址
    {
      var suffixLen = email.Length - email.LastIndexOf('@');
      return HideSensitiveInfo(email, left, suffixLen, false);
    }

    return HideSensitiveInfo(email);
  }
  /// <summary>
  ///   解析版本
  /// </summary>
  /// <param name="version"></param>
  /// <returns></returns>
  public static int ParseVersion(this string version)
  {
    var sp = version.Split('.');
    var num = "";
    foreach (var item in sp) num = num + item.PadLeft(2, '0');
    return int.Parse(num);
  }
}