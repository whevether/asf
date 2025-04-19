using System;
using System.Collections.Generic;

namespace ASF.Application.DTO.Role;

/// <summary>
///   角色响应
/// </summary>
public class RoleResponseDto : RoleModifyRequestDto
{
	/// <summary>
	///   key
	/// </summary>
	public string Key { get; set; }

	/// <summary>
	///   创建者id
	/// </summary>
	public string CreateId { get; set; }

	/// <summary>
	///   创建时间
	/// </summary>
	public DateTime CreateTime { get; set; }

	/// <summary>
	///   角色权限
	/// </summary>
	public List<PermissionResponseDto> Permission { get; set; }

	/// <summary>
	///   角色关联部门集合
	/// </summary>
	public List<object> Department { get; set; }
}