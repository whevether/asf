using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Tenancy;

/// <summary>
///   租户分页请求
/// </summary>
public class TenancyListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   租户名
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_TenancyNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_TenancyNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   租户状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_StatusRange01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }
}