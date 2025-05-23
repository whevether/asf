﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using ASF.Internal;

namespace ASF.Domain.Entities;

/// <summary>
///   权限
/// </summary>
public class Permission : Entity<long>
{
    /// <summary>
    ///   权限
    /// </summary>
    public Permission()
  {
    Role = new JoinCollectionFacade<Role, Permission, PermissionRole>(this, PermissionRole);
  }

    /// <summary>
    ///   权限代码
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    ///   上级权限编号
    /// </summary>
    public long? ParentId { get; set; }

    /// <summary>
    ///   名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   权限类型
    /// </summary>
    public uint Type { get; set; }

    /// <summary>
    ///   是否系统权限
    /// </summary>
    public uint? IsSystem { get; set; }

    /// <summary>
    ///   描述
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///   排序
    /// </summary>
    public int? Sort { get; set; }

    /// <summary>
    ///   是否启用
    /// </summary>
    public uint? Enable { get; set; }

    /// <summary>
    ///   租户id
    /// </summary>
    public long? TenancyId { get; set; }

    /// <summary>
    ///   添加时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    ///   关联权限到角色
    /// </summary>
    [NotMapped]
  public ICollection<Role> Role { get; }

    /// <summary>
    ///   权限角色中间表
    /// </summary>
    public ICollection<PermissionRole> PermissionRole { get; } = new List<PermissionRole>();

    /// <summary>
    ///   权限菜单
    /// </summary>
    [NotMapped]
  public PermissionMenu PermissionMenus { get; }

    /// <summary>
    ///   对应权限api
    /// </summary>
    [NotMapped]
  public ICollection<Api> Apis { get; } = new List<Api>();
}