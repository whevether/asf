using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository
{
	/// <summary>
	/// 权限菜单仓储
	/// </summary>
	public class MenuRepositories: Repositories<PermissionMenu>, IMenuRepositories
	{
		public MenuRepositories(RepositoryContext context) : base(context)
		{
		}
		/// <summary>
		/// 获取权限菜单详情
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tenancyId"></param>
		/// <returns></returns>
		public async Task<PermissionMenu> GetPermissionMenuAsync(long id,long? tenancyId = null)
		{
			if(tenancyId != null)
			 return await base.GetDbContext().PermissionMenu.Include(f => f.Permissions)
				.FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
			return await base.GetDbContext().PermissionMenu.Include(f => f.Permissions)
				.FirstOrDefaultAsync(f => f.Id == id);
		}

		public async Task<(IList<PermissionMenu> list,int total)> GetEntitiesForPaging(int pageNo, int pageSize, string permissionId = "", string title = "", string menuUrl = "",
			long? tenancyId = null)
		{
			List<PermissionMenu> query = new List<PermissionMenu>();
			if (tenancyId != null)
			{
				if (!string.IsNullOrEmpty(permissionId) || !string.IsNullOrEmpty(title) ||
				    !string.IsNullOrEmpty(menuUrl))
					query = await base.GetDbContext().PermissionMenu.Include(f => f.Permissions).Where(w =>
						w.TenancyId == tenancyId &&
						(w.PermissionId.ToString().Equals(permissionId) || w.Title.Contains(title) ||
						 w.MenuUrl.Contains(menuUrl))).ToListAsync();
				else
					query = await base.GetDbContext().PermissionMenu.Include(f => f.Permissions)
						.Where(w => w.TenancyId == tenancyId).ToListAsync();

			}
			else
			{
				if (!string.IsNullOrEmpty(permissionId) || !string.IsNullOrEmpty(title) ||
				    !string.IsNullOrEmpty(menuUrl))
					query = await base.GetDbContext().PermissionMenu.Include(f => f.Permissions).Where(w =>
						w.PermissionId.ToString().Equals(permissionId) || w.Title.Contains(title) ||
						 w.MenuUrl.Contains(menuUrl)).ToListAsync();
				else
					query = await base.GetDbContext().PermissionMenu.Include(f => f.Permissions)
						.Where(w => w.Id != 0).ToListAsync();
			}
			int count = query.Count();
			int p = pageNo == 0 ? 1 : pageNo;
			int c = pageSize == 0 ? count : pageSize;
			// int totalPages = (int)Math.Ceiling(((decimal)count / c));
			// p = Math.Min(p, totalPages);
			var list = query
				.Skip((p - 1) * c)
				.Take(c)
				.ToList();
			return await Task.FromResult<(IList<PermissionMenu> list,  int total)>((list, count));
		}
	}
}