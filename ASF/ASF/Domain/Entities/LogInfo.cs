using System;
using ASF.Domain.Values;
using ASF.Internal.Security;

namespace ASF.Domain.Entities;

/// <summary>
///   日志
/// </summary>
public class LogInfo : Entity<long>
{
  /// <summary>
  ///   操作账号编号
  /// </summary>
  public long? AccountId { get; private set; }

  /// <summary>
  ///   操作账户名
  /// </summary>
  public string AccountName { get; set; }

  /// <summary>
  ///   日志类型
  /// </summary>
  public uint Type { get; private set; }

  /// <summary>
  ///   登录方式
  /// </summary>
  public string Subject { get; private set; }

  /// <summary>
  ///   客户端IP
  /// </summary>
  public string ClientIp { get; set; }

  /// <summary>
  ///   客户端位置
  /// </summary>
  public string ClientLocation { get; set; }

  /// <summary>
  ///   权限ID
  /// </summary>
  public long? PermissionId { get; set; }

  /// <summary>
  ///   日志记录时间
  /// </summary>
  public DateTime AddTime { get; set; }

  /// <summary>
  ///   请求地址
  /// </summary>
  public string ApiAddress { get; set; }

  /// <summary>
  ///   API请求数据
  /// </summary>
  public string ApiRequest { get; set; }

  /// <summary>
  ///   响应数据
  /// </summary>
  public string ApiResponse { get; set; }

  /// <summary>
  ///   备注
  /// </summary>
  public string Remark { get; set; }

  #region 方法

  /// <summary>
  ///   设置登入日志
  /// </summary>
  /// <param name="accountId"></param>
  /// <param name="accountName"></param>
  /// <param name="subject"></param>
  /// <param name="type"></param>
  /// <param name="ip"></param>
  /// <param name="location"></param>
  public void SetLogin(long accountId, string accountName, string subject, LoggingType type, string ip,
    string location)
  {
    AccountId = accountId;
    AccountName = accountName;
    Subject = subject;
    Type = (uint)type;
    if (!string.IsNullOrEmpty(ip))
      ClientIp = ip;
    if (!string.IsNullOrEmpty(location))
      ClientLocation = location;
  }

  /// <summary>
  ///   设置权限操作日志
  /// </summary>
  /// <param name="accountId"></param>
  /// <param name="accountName"></param>
  /// <param name="subject"></param>
  /// <param name="type"></param>
  /// <param name="permissionId"></param>
  /// <param name="apiAddress"></param>
  /// <param name="request"></param>
  /// <param name="response"></param>
  /// <param name="ip"></param>
  public void SetOperate(long accountId, string accountName, string subject, LoggingType type, long? permissionId,
    string apiAddress, string request, string ip, string response)
  {
    AccountId = accountId;
    AccountName = accountName;
    Subject = subject;
    Type = (uint)type;
    ApiAddress = apiAddress;
    ApiRequest = request;
    PermissionId = permissionId;
    if (!string.IsNullOrEmpty(response))
      ApiResponse = response;
    if (!string.IsNullOrEmpty(ip))
    {
      ClientIp = ip;
      if (ip.Equals("127.0.0.1"))
      {
        ClientLocation = "本地";
      }
      else
      {
        var ipConvertValue = Helper.GetIpCitys(ip);
        if (ipConvertValue != null)
          ClientLocation =
            $"{ipConvertValue.Country},{ipConvertValue.RegionName},{ipConvertValue.City}";
        else
          ClientLocation = "未知";
      }
    }
  }

  #endregion
}