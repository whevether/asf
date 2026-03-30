using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   权限分页列表请求
/// </summary>
public class PermissionListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   权限代码
	/// </summary>
	[MaxLength(50, ErrorMessageResourceName = "Val_PermissionCodeMaxLength50", ErrorMessageResourceType = typeof(SharedResource))]
  public string Code { get; set; }

	/// <summary>
	///   权限名称
	/// </summary>
	[MaxLength(100, ErrorMessageResourceName = "Val_PermissionNameMaxLength100", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   权限类型
	/// </summary>
	[Range(1, 3, ErrorMessageResourceName = "Val_PermissionTypeRange13", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Type { get; set; }

	/// <summary>
	///   是否为系统权限
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_IsSystemPermission01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? IsSystem { get; set; }

	/// <summary>
	///   权限状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_PermissionStatus01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }
}