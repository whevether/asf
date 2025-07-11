using ASF.Application.DTO;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   权限映射
/// </summary>
public class PermissionMapper : Profile
{
  /// <summary>
  ///   权限映射
  /// </summary>
  public PermissionMapper()
  {
    #region api permission

    // 权限功能映射
    CreateMap<Api, PermissionApiResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.StatusName, s => s.MapFrom(o => o.Status == 0 ? "禁用" : "启用"))
      .ForMember(f => f.TypeName, s => s.MapFrom(o => o.Type == 1 ? "公开api" : "授权api")).ForMember(
        f => f.Permission,
        s => s.MapFrom(o => o.Permission != null
          ? new
          {
            Key = o.Permission.Id.ToString(),
            Id = o.Permission.Id.ToString(),
            o.Permission.Code,
            ParentId = o.Permission.ParentId.ToString(),
            o.Permission.Name,
            o.Permission.Type,
            o.Permission.IsSystem,
            o.Permission.Description,
            o.Permission.Sort,
            o.Permission.Enable,
            TenancyId = o.Permission.TenancyId.ToString(),
            o.Permission.CreateTime
          }
          : null));
    // 创建权限功能
    CreateMap<PermissionApiCreateRequestDto, Api>();
    // 修改权限功能
    CreateMap<PermissionApiModifyRequestDto, Api>();

    #endregion

    #region menu permission

    //权限菜单响应
    CreateMap<PermissionMenu, PermissionMenuResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.Permission, s => s.MapFrom(o => o.Permissions != null
        ? new
        {
          Key = o.Permissions.Id.ToString(),
          Id = o.Permissions.Id.ToString(),
          o.Permissions.Code,
          ParentId = o.Permissions.ParentId.ToString(),
          o.Permissions.Name,
          o.Permissions.Type,
          o.Permissions.IsSystem,
          o.Permissions.Description,
          o.Permissions.Sort,
          o.Permissions.Enable,
          TenancyId = o.Permissions.TenancyId.ToString(),
          o.Permissions.CreateTime
        }
        : null));
    // 创建权限菜单
    CreateMap<PermissionMenuCreateRequestDto, PermissionMenu>();
    //修改权限菜单
    CreateMap<PermissionMenuModifyRequestDto, PermissionMenu>();

    #endregion

    #region permission

    //权限响应数据
    CreateMap<Permission, PermissionResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id));
    // 创建权限请求
    CreateMap<PermissionCreateRequestDto, Permission>();
    //修改权限
    CreateMap<PermissionModifyRequestDto, Permission>();

    #endregion

    // 登录信息权限菜单映射
    CreateMap<Permission, PermissionMenuInfoResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.PermissionMenus.Id))
      .ForMember(f => f.Title, s => s.MapFrom(o => o.PermissionMenus.Title))
      .ForMember(f => f.Subtitle, s => s.MapFrom(o => o.PermissionMenus.Subtitle))
      .ForMember(f => f.Icon, s => s.MapFrom(o => o.PermissionMenus.Icon))
      .ForMember(f => f.MenuHidden, s => s.MapFrom(o => o.PermissionMenus.MenuHidden))
      .ForMember(f => f.MenuUrl, s => s.MapFrom(o => o.PermissionMenus.MenuUrl))
      .ForMember(f => f.MenuRedirect, s => s.MapFrom(o => o.PermissionMenus.MenuRedirect))
      .ForMember(f => f.ExternalLink, s => s.MapFrom(o => o.PermissionMenus.ExternalLink))
      .ForMember(f => f.PermissionDescription, s => s.MapFrom(o => o.Description))
      .ForMember(f => f.Translate, s => s.MapFrom(o => o.PermissionMenus.Translate));
    // .ForMember(f => f.Actions, s => s.MapFrom(o => o.Apis.Select(a => new Regex("/").Replace(a.Path, "",1).Replace("api/asf/","").Replace("/",".")).ToList()));
  }
}