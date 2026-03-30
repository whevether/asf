using ASF.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASF.Application.DTO.Role;

/// <summary>
///   修改角色请求
/// </summary>
public class RoleModifyRequestDto : RoleCreateRequestDto
{
	/// <summary>
	///   角色id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_RoleIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   要分配的权限id集合
	/// </summary>
	[NotMapped]
  public List<string> PermissionId { get; set; }
}