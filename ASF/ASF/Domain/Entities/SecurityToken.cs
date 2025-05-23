using System;

namespace ASF.Domain.Entities;

/// <summary>
///   token 黑名单
/// </summary>
public class SecurityToken : Entity<long>
{
  /// <summary>
  ///   账户id
  /// </summary>
  public long? AccountId { get; set; }

  /// <summary>
  ///   黑名单token
  /// </summary>
  public string Token { get; set; }

  /// <summary>
  ///   token 过期时间
  /// </summary>
  public DateTime? TokenExpired { get; set; }

  /// <summary>
  ///   创建时间
  /// </summary>
  public DateTime CreateTime { get; set; }
}