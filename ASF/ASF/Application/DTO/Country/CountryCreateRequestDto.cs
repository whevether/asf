using ASF.Resources;
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
  [Required(ErrorMessageResourceName = "Val_CountryNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

  /// <summary>
  ///   国家代码 code
  /// </summary>
  [Required(ErrorMessageResourceName = "Val_CountryCodeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string LanguageCode { get; set; }

  /// <summary>
  ///   国家币种代码
  /// </summary>
  [Required(ErrorMessageResourceName = "Val_CountryCurrencyCodeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string CurrencyType { get; set; }

  /// <summary>
  ///   国家与RMB之间汇率
  /// </summary>
  [Required(ErrorMessageResourceName = "Val_CountryExchangeRateRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public decimal? Ratio { get; set; }

  /// <summary>
  ///   提现手续费利率
  /// </summary>
  [Required(ErrorMessageResourceName = "Val_WithdrawFeeRateRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public decimal? WithdrawalRatio { get; set; }

  /// <summary>
  ///   状态 0 禁用， 1 启用
  /// </summary>
  [Range(0, 1, ErrorMessageResourceName = "Val_StatusRange01Num", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Status { get; set; }
}
