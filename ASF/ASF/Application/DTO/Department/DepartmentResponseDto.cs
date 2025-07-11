using System;
using System.Collections.Generic;

namespace ASF.Application.DTO.Department;

/// <summary>
///   部门响应
/// </summary>
public class DepartmentResponseDto : DepartmentModifyRequestDto
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
  ///   部门对应的角色id与名称
  /// </summary>
  public List<object> Roles { get; set; }

  /// <summary>
  ///   部门所属用户
  /// </summary>
  public List<object> Accounts { get; set; }

  /// <summary>
  ///   子集合
  /// </summary>
  public IEnumerable<DepartmentResponseDto> Children { get; set; }
}