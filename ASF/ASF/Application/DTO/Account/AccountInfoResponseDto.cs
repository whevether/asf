using System.Collections.Generic;

namespace ASF.Application.DTO;

/// <summary>
///   登录账户信息
/// </summary>
public class AccountInfoResponseDto
{
  /// <summary>
  ///   账户id
  /// </summary>
  public string Id { get; set; }

  /// <summary>
  ///   租户id
  /// </summary>
  public string TenancyId { get; set; }

  /// <summary>
  ///   部门id
  /// </summary>
  public string DepartmentId { get; set; }

  /// <summary>
  ///   昵称
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  ///   用户名
  /// </summary>
  public string Username { get; set; }

  /// <summary>
  ///   手机号码
  /// </summary>
  public string TelPhone { get; set; }

  /// <summary>
  ///   邮箱地址
  /// </summary>
  public string Email { get; set; }

  /// <summary>
  ///   性别
  /// </summary>
  public int? Sex { get; set; }

  /// <summary>
  ///   账户头像
  /// </summary>
  public string Avatar { get; set; }

  /// <summary>
  ///   账户状态
  /// </summary>
  public uint? Status { get; set; }

  /// <summary>
  ///   账户角色名
  /// </summary>
  public string RoleName { get; set; }

  /// <summary>
  ///   动作权限
  /// </summary>
  public List<string> Actions { get; set; } = new();

  /// <summary>
  ///   面包屑
  /// </summary>
  public Dictionary<string, string> BreadcrumbItems { get; set; }

  /// <summary>
  ///   权限菜单
  /// </summary>
  public List<PermissionMenuTreeItem<PermissionMenuInfoResponseDto>> PermissionMenu { get; set; }
}