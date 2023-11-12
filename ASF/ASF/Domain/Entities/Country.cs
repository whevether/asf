using System;

namespace ASF.Domain.Entities;

/// <summary>
///  国家实体对象
/// </summary>
public class Country: Entity<long>
{
  /// <summary>
  /// 国家名称
  /// </summary>
  public string Name { get; set; }
  /// <summary>
  /// 国家代码 code
  /// </summary>
  public string LanguageCode { get; set; }
  /// <summary>
  /// 国家币种
  /// </summary>
  public string CurrencyType { get; set; }
  /// <summary>
  /// 国家与RMB之间汇率
  /// </summary>
  public decimal Ratio { get; set; }
  /// <summary>
  /// 提现手续费利率
  /// </summary>
  public decimal WithdrawalRatio { get; set; }
  /// <summary>
  /// 状态 0 禁用， 1 启用
  /// </summary>
  public int Status { get; set; }
  /// <summary>
  /// 创建时间
  /// </summary>
  public DateTime CreateTime { get; set; }
  /// <summary>
  /// 创建时间
  /// </summary>
  public DateTime UpdateTime { get; set; }
}