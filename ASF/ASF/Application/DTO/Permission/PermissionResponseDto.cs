using System;
using System.Collections.Generic;

namespace ASF.Application.DTO;

/// <summary>
///   权限响应数据
/// </summary>
public class PermissionResponseDto : PermissionModifyRequestDto
{
	/// <summary>
	///   key
	/// </summary>
	public string Key { get; set; }

	/// <summary>
	///   标签
	/// </summary>
	public string Label { get; set; }

	/// <summary>
	///   value
	/// </summary>
	public string Value { get; set; }

	/// <summary>
	///   创建时间
	/// </summary>
	public DateTime CreateTime { get; set; }

	/// <summary>
	///   子集合
	/// </summary>
	public IEnumerable<PermissionResponseDto> Children { get; set; }

	/// <summary>
	///   权限菜单
	/// </summary>
	public PermissionMenuResponseDto PermissionMenus { get; set; }

	/// <summary>
	///   权限api
	/// </summary>
	public List<PermissionApiResponseDto> Apis { get; set; }
}