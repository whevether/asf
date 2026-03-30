using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   创建权限
/// </summary>
public class PermissionCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   权限代码
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_PermissionCodeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_PermissionCodeMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Code { get; set; }

	/// <summary>
	///   上级权限编号
	/// </summary>
	public string ParentId { get; set; }

	/// <summary>
	///   名称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_PermissionNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_PermissionNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   权限类型
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_PermissionTypeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [Range(1, 3, ErrorMessageResourceName = "Val_PermissionTypeRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Type { get; set; }

	/// <summary>
	///   是否系统权限
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_IsSystemPermissionRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? IsSystem { get; set; }

	/// <summary>
	///   描述
	/// </summary>
	[MaxLength(500, ErrorMessageResourceName = "Val_DescriptionMaxLength500", ErrorMessageResourceType = typeof(SharedResource))]
  public string Description { get; set; }

	/// <summary>
	///   排序
	/// </summary>
	[Range(0, 100, ErrorMessageResourceName = "Val_SortOrderRange", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Sort { get; set; }

	/// <summary>
	///   是否启用
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_EnabledRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Enable { get; set; }
}
