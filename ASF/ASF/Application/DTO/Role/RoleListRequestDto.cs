using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Role;

/// <summary>
///   角色分页请求
/// </summary>
public class RoleListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   角色名称
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_RoleNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_RoleNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   是否启用
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_EnabledRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Enable { get; set; }
}