using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Role;

/// <summary>
///   创建角色
/// </summary>
public class RoleCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   角色名称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_RoleNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_RoleNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_RoleNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   描述
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_RoleNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_RoleNameMaxLength255", ErrorMessageResourceType = typeof(SharedResource))]
  public string Description { get; set; }

	/// <summary>
	///   是否启用
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_EnabledRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Enable { get; set; }
}