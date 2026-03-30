using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Tenancy;

/// <summary>
///   创建租户
/// </summary>
public class TenancyCreateRequestDto
{
	/// <summary>
	///   租户名
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_TenancyNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_TenancyNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_TenancyNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   排序
	/// </summary>
	[Range(0, 100, ErrorMessageResourceName = "Val_SortRange100", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Sort { get; set; }

	/// <summary>
	///   等级
	/// </summary>
	[Range(0, 10, ErrorMessageResourceName = "Val_LevelRange", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Level { get; set; }

	/// <summary>
	///   租户状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_StatusRange01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }
}