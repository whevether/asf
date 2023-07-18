using System.Linq;
using System.Text.RegularExpressions;
using ASF.Application.DTO;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using AutoMapper;

namespace ASF.Application.DtoMapper
{
	/// <summary>
	/// 权限映射
	/// </summary>
	public class PermissionMapper: Profile
	{
		/// <summary>
		/// 权限映射
		/// </summary>
		public PermissionMapper()
		{
			#region api permission

			// 权限功能映射
			this.CreateMap<Api, PermissionApiResponseDto>()
				.ForMember(f=>f.Key,s=>s.MapFrom(o=>o.Id))
				.ForMember(f => f.StatusName, s => s.MapFrom(o => o.Status == 0 ? "禁用":"启用"))
				.ForMember(f => f.TypeName, s => s.MapFrom(o => o.Type == 1 ? "公开api" : "授权api")).ForMember(f=>f.Permission,s=>s.MapFrom(o=>o.Permission != null ? new
				{
					Key = o.Permission.Id.ToString(),
					Id = o.Permission.Id.ToString(),
					Code = o.Permission.Code,
					ParentId = o.Permission.ParentId.ToString(),
					Name = o.Permission.Name,
					Type = o.Permission.Type,
					IsSystem = o.Permission.IsSystem,
					Description = o.Permission.Description,
					Sort = o.Permission.Sort,
					Enable = o.Permission.Enable,
					TenancyId = o.Permission.TenancyId.ToString(),
					CreateTime = o.Permission.CreateTime
				}: null));
			// 创建权限功能
			this.CreateMap<PermissionApiCreateRequestDto, Api>();
			// 修改权限功能
			this.CreateMap<PermissionApiModifyRequestDto, Api>();

			#endregion

			#region menu permission

			//权限菜单响应
			this.CreateMap<PermissionMenu,PermissionMenuResponseDto>()
				.ForMember(f=>f.Key,s=>s.MapFrom(o=>o.Id))
				.ForMember(f=>f.Permission,s=>s.MapFrom(o=>o.Permissions != null ? new
				{
					Key = o.Permissions.Id.ToString(),
					Id = o.Permissions.Id.ToString(),
					Code = o.Permissions.Code,
					ParentId = o.Permissions.ParentId.ToString(),
					Name = o.Permissions.Name,
					Type = o.Permissions.Type,
					IsSystem = o.Permissions.IsSystem,
					Description = o.Permissions.Description,
					Sort = o.Permissions.Sort,
					Enable = o.Permissions.Enable,
					TenancyId = o.Permissions.TenancyId.ToString(),
					CreateTime = o.Permissions.CreateTime
				}: null));
			// 创建权限菜单
			this.CreateMap<PermissionMenuCreateRequestDto, PermissionMenu>();
			//修改权限菜单
			this.CreateMap<PermissionMenuModifyRequestDto, PermissionMenu>();
			#endregion

			#region permission
			//权限响应数据
			this.CreateMap<Permission, PermissionResponseDto>()
				.ForMember(f=>f.Key,s=>s.MapFrom(o=>o.Id));
			// 创建权限请求
			this.CreateMap<PermissionCreateRequestDto, Permission>();
			//修改权限
			this.CreateMap<PermissionModifyRequestDto, Permission>();
			#endregion
			// 登录信息权限菜单映射
			this.CreateMap<Permission, PermissionMenuInfoResponseDto>()
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
}