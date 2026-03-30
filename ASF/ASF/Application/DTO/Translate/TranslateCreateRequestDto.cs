using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Translate;

/// <summary>
///   创建多语言
/// </summary>
public class TranslateCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   多语言名称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_TranslateNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_TranslateNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_TranslateNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }
	

	/// <summary>
	///   国家语言code 利用国家code 分组 例如zh en 等等
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_CountryCodeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string CountryCode { get; set; }

	/// <summary>
	///   多语言key
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_TranslateKeyRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_TranslateKeyMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(500, ErrorMessageResourceName = "Val_TranslateKeyMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Key { get; set; }

	/// <summary>
	///   多语言值
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_TranslateValueRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_TranslateValueMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(5000, ErrorMessageResourceName = "Val_TranslateValueMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Value { get; set; }

	/// <summary>
	///   是否为管理后台
	/// </summary>
	public uint? IsAdmin { get; set; }
}
