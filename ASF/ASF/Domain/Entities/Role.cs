﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ASF.Internal;

namespace ASF.Domain.Entities;

/// <summary>
///   角色
/// </summary>
public class Role : Entity<long>
{
    /// <summary>
    ///   角色
    /// </summary>
    public Role()
  {
    Permission = new JoinCollectionFacade<Permission, Role, PermissionRole>(this, PermissionRole);
    Account = new JoinCollectionFacade<Account, Role, AccountRole>(this, AccountRole);
    Department =
      new JoinCollectionFacade<Department, Role, DepartmentRole>(this, DepartmentRole);
  }

    /// <summary>
    ///   租户id
    /// </summary>
    public long? TenancyId { get; set; }

    /// <summary>
    ///   角色名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///   是否启用
    /// </summary>
    public uint? Enable { get; set; }

    /// <summary>
    ///   创建用户
    /// </summary>
    public long CreateId { get; set; }

    /// <summary>
    ///   创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    ///   关联权限
    /// </summary>
    [NotMapped]
  public ICollection<Permission> Permission { get; }

    /// <summary>
    ///   角色权限中间表
    /// </summary>
    public ICollection<PermissionRole> PermissionRole { get; } = new List<PermissionRole>();

    /// <summary>
    ///   关联账户
    /// </summary>
    [NotMapped]
  public ICollection<Account> Account { get; }

    /// <summary>
    ///   角色账户中间表
    /// </summary>
    public ICollection<AccountRole> AccountRole { get; } = new List<AccountRole>();

    /// <summary>
    ///   关联部门
    /// </summary>
    [NotMapped]
  public ICollection<Department> Department { get; }

    /// <summary>
    ///   角色账户中间表
    /// </summary>
    public ICollection<DepartmentRole> DepartmentRole { get; } = new List<DepartmentRole>();
}