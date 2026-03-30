using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Entities;

namespace ASF.Infrastructure.Repositories;

/// <summary>
///   权限菜单仓储
/// </summary>
public interface IMenuRepositories : IRepositories<PermissionMenu>
{
	/// <summary>
	///   获取权限菜单详情
	/// </summary>
	/// <param name="id"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<PermissionMenu> GetPermissionMenuAsync(long id, long? tenancyId = null);

	/// <summary>
	///   获取权限菜单列表
	/// </summary>
	/// <param name="pageNo"></param>
	/// <param name="pageSize"></param>
	/// <param name="permissionId"></param>
	/// <param name="title"></param>
	/// <param name="menuUrl"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<(IList<PermissionMenu> list, int total)> GetEntitiesForPaging(int pageNo, int pageSize, string permissionId = "",
    string title = "", string menuUrl = "", long? tenancyId = null);
}