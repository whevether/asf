using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ASF.Domain.Values;
using ASF.Internal;
using ASF.Internal.Results;
using ASF.Internal.Security;
using AccessToken = ASF.Domain.Values.AccessToken;

namespace ASF.Domain.Entities;

/// <summary>
///   账户模型
/// </summary>
public class Account : Entity<long>
{
  /// <summary>
  ///   账户模型
  /// </summary>
  public Account()
  {
    Role = new JoinCollectionFacade<Role, Account, AccountRole>(this, AccountRole);
    Post = new JoinCollectionFacade<Post, Account, AccountPost>(this, AccountPost);
  }

  #region 属性

  /// <summary>
  ///   租户id
  /// </summary>
  public long? TenancyId { get; set; }

  /// <summary>
  ///   部门id
  /// </summary>
  public long? DepartmentId { get; set; }

  /// <summary>
  ///   昵称
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  ///   用户名
  /// </summary>
  public string Username { get; set; }

  /// <summary>
  ///   登录密码
  /// </summary>
  public string Password { get; private set; }

  /// <summary>
  ///   密码加盐
  /// </summary>
  public string PasswordSalt { get; set; } = Guid.NewGuid().ToString();

  /// <summary>
  ///   手机号码
  /// </summary>
  public string TelPhone { get; private set; }

  /// <summary>
  ///   邮箱地址
  /// </summary>
  public string Email { get; private set; }

  /// <summary>
  ///   头像
  /// </summary>
  public string Avatar { get; set; }

  /// <summary>
  ///   状态
  /// </summary>
  public uint? Status { get; set; }

  /// <summary>
  ///   是否删除
  /// </summary>
  public uint? IsDeleted { get; set; }

  /// <summary>
  ///   性别
  /// </summary>
  public uint? Sex { get; set; }

  /// <summary>
  ///   创建用户
  /// </summary>
  public long? CreateId { get; set; }

  /// <summary>
  ///   创建时间
  /// </summary>
  public DateTime CreateTime { get; set; }

  /// <summary>
  ///   最后登录IP
  /// </summary>
  public string LoginIp { get; set; }

  /// <summary>
  ///   最后登录时间
  /// </summary>
  public DateTime? LoginTime { get; set; }

  /// <summary>
  ///   最近登录位置
  /// </summary>
  public string LoginLocation { get; set; }

  /// <summary>
  ///   Token
  /// </summary>
  public string Token { get; set; }

  /// <summary>
  ///   刷新令牌
  /// </summary>
  public string RefreshToken { get; set; }

  /// <summary>
  ///   过期时间
  /// </summary>
  public DateTime? Expired { get; set; }

  /// <summary>
  ///   关联角色
  /// </summary>
  [NotMapped]
  public ICollection<Role> Role { get; }

  /// <summary>
  ///   角色账户中间表
  /// </summary>
  public ICollection<AccountRole> AccountRole { get; } = new List<AccountRole>();

  /// <summary>
  ///   关联岗位
  /// </summary>
  [NotMapped]
  public ICollection<Post> Post { get; }

  /// <summary>
  ///   角色账户中间表
  /// </summary>
  public ICollection<AccountPost> AccountPost { get; } = new List<AccountPost>();

  /// <summary>
  ///   多个用户关联一个租户
  /// </summary>
  [NotMapped]
  public Tenancy Tenancys { get; set; }

  /// <summary>
  ///   一个用户关联一个部门
  /// </summary>
  [NotMapped]
  public Department Department { get; set; }

  #endregion

  #region 方法

  /// <summary>
  ///   设置用户密码
  /// </summary>
  public Result SetPassword(string passsword)
  {
    // this.PasswordSalt = Guid.NewGuid().ToString();
    var newPassword = PasswordHelper.GeneratePasswordHash(passsword, PasswordSalt);
    if (newPassword == Password)
      return Result.ReFailure(ResultCodes.AccountOldPasswordAndNewPasswordSame);
    Password = newPassword;
    return Result.ReSuccess();
  }

  /// <summary>
  ///   设置用户手机号码
  /// </summary>
  public void SetPhone(string phone, int area)
  {
    TelPhone = new PhoneNumber(phone, area).ToString();
  }

  /// <summary>
  ///   设置用户邮箱
  /// </summary>
  public void SetEmail(string email)
  {
    Email = email;
  }

  /// <summary>
  ///   设置用户名
  /// </summary>
  /// <param name="username"></param>
  public void SetUserName(string username)
  {
    Username = username;
  }

  /// <summary>
  ///   是否允许登录
  /// </summary>
  /// <returns></returns>
  public bool IsAllowLogin()
  {
    var isDeleted = IsDeleted;
    if (isDeleted != null && (Status)isDeleted == Values.Status.Yes)
      return false;
    if (Status != null && (EnabledType)Status != EnabledType.Enable)
      return false;
    return true;
  }

  /// <summary>
  ///   设置登录信息
  /// </summary>
  /// <param name="token"></param>
  /// <param name="ip"></param>
  public void SetLoginInfo(AccessToken token, string ip)
  {
    if (!string.IsNullOrEmpty(token.Token))
      Token = token.Token;
    if (!string.IsNullOrEmpty(token.RefreshToken))
      RefreshToken = token.RefreshToken;
    Expired = token.Expired;
    LoginTime = DateTime.UtcNow;
    if (!string.IsNullOrEmpty(ip))
    {
      LoginIp = ip;
      if (ip.Equals("127.0.0.1"))
      {
        LoginLocation = "本地";
      }
      else
      {
        var ipConvertValue = Helper.GetIpCitys(ip);
        if (ipConvertValue != null)
          LoginLocation =
            $"{ipConvertValue.Country},{ipConvertValue.RegionName},{ipConvertValue.City}";
        else
          LoginLocation = "未知";
      }
    }
  }

  /// <summary>
  ///   删除
  /// </summary>
  public void Delete()
  {
    IsDeleted = (uint)Values.Status.Yes;
  }

  #endregion
}