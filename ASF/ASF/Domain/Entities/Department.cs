using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ASF.Internal;

namespace ASF.Domain.Entities;

/// <summary>
///   部门
/// </summary>
public class Department : Entity<long>
{
  /// <summary>
  ///   部门
  /// </summary>
  public Department()
  {
    Role = new JoinCollectionFacade<Role, Department, DepartmentRole>(this, DepartmentRole);
  }

  /// <summary>
  ///   父id
  /// </summary>
  public long Pid { get; set; }

  /// <summary>
  ///   租户id
  /// </summary>
  public long? TenancyId { get; set; }

  /// <summary>
  ///   部门名称
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  ///   是否启用
  /// </summary>
  public uint? Enable { get; set; }

  /// <summary>
  ///   排序
  /// </summary>
  public int? Sort { get; set; }

  /// <summary>
  ///   创建时间
  /// </summary>
  public DateTime CreateTime { get; set; }


  /// <summary>
  ///   角色
  /// </summary>
  [NotMapped]
  public ICollection<Role> Role { get; }

  /// <summary>
  ///   部门账户中间表
  /// </summary>
  public ICollection<DepartmentRole> DepartmentRole { get; } = new List<DepartmentRole>();

  /// <summary>
  ///   账户下面所属部门
  /// </summary>
  [NotMapped]
  public ICollection<Account> Accounts { get; set; } = new List<Account>();
}