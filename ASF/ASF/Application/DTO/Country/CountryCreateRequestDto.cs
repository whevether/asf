using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Country;

/// <summary>
///   创建 国家请求dot
/// </summary>
public class CountryCreateRequestDto
{
  /// <summary>
  ///   国家名称
  /// </summary>
  [Required(ErrorMessage = "国家名称不能为空")]
  public string Name { get; set; }

  /// <summary>
  ///   国家代码 code
  /// </summary>
  [Required(ErrorMessage = "国家代码不能为空")]
  public string LanguageCode { get; set; }

  /// <summary>
  ///   国家币种代码
  /// </summary>
  [Required(ErrorMessage = "国家币种代码不能为空")]
  public string CurrencyType { get; set; }

  /// <summary>
  ///   国家与RMB之间汇率
  /// </summary>
  [Required(ErrorMessage = "国家与RMB之间汇率不能为空")]
  public decimal? Ratio { get; set; }

  /// <summary>
  ///   提现手续费利率
  /// </summary>
  [Required(ErrorMessage = "提现手续费利率不能为空")]
  public decimal? WithdrawalRatio { get; set; }

  /// <summary>
  ///   状态 0 禁用， 1 启用
  /// </summary>
  [Range(0, 1, ErrorMessage = "状态只能为0到1之间的数字")]
  public int? Status { get; set; }
}