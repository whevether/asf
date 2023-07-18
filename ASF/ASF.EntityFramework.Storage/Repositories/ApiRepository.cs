using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository
{
  /// <summary>
  /// api仓储
  /// </summary>
  public class ApiRepository: Repositories<Api>, IApiRepository
  {
    public ApiRepository(RepositoryContext context) : base(context)
    {
    }
    /// <summary>
    /// 获取权限功能详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tenancyId"></param>
    /// <returns></returns>
    public async Task<Api> GetApiAsync(long id,long? tenancyId = null)
    {
      if (tenancyId != null)
        await base.GetDbContext().Api.Include(f => f.Permission)
          .FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
      return await base.GetDbContext().Api.Include(f => f.Permission).FirstOrDefaultAsync(f => f.Id == id);
    }
    /// <summary>
    /// 获取api列表
    /// </summary>
    /// <param name="pageNo"></param>
    /// <param name="pageSize"></param>
    /// <param name="permissionId"></param>
    /// <param name="type"></param>
    /// <param name="status"></param>
    /// <param name="name"></param>
    /// <param name="httpMethod"></param>
    /// <param name="path"></param>
    /// <param name="tenancyId"></param>
    /// <returns></returns>
    public async Task<(IList<Api> list, int total)> GetEntitiesForPaging(int pageNo, int pageSize, string permissionId = "", uint? type = null, uint? status = null,
      string name = "", string httpMethod = "", string path = "", long? tenancyId = null)
    {
      List<Api> query = new List<Api>();
      if (tenancyId != null)
      {
        if (!string.IsNullOrEmpty(permissionId) || type != null || status != null || !string.IsNullOrEmpty(name) ||
            !string.IsNullOrEmpty(httpMethod) || !string.IsNullOrEmpty(path))
          query = await base.GetDbContext().Api.Include(f => f.Permission).Where(w =>
            (w.PermissionId.ToString().Equals(permissionId) || w.Type == type || w.Status == status ||
             w.Name.Contains(name) || w.HttpMethods.Equals(httpMethod) || w.Path.Contains(path)) &&
            w.TenancyId == tenancyId).ToListAsync();
        else
          query = await base.GetDbContext().Api.Include(f => f.Permission).Where(w =>w.TenancyId == tenancyId).ToListAsync();
      }
      else
      {
        if (!string.IsNullOrEmpty(permissionId) || type != null || status != null || !string.IsNullOrEmpty(name) ||
            !string.IsNullOrEmpty(httpMethod) || !string.IsNullOrEmpty(path))
          query = await base.GetDbContext().Api.Include(f => f.Permission).Where(w => w.PermissionId.ToString().Equals(permissionId) || w.Type == type || w.Status == status ||
             w.Name.Contains(name) || w.HttpMethods.Equals(httpMethod) || w.Path.Contains(path)).ToListAsync();
        else
          query = await base.GetDbContext().Api.Include(f => f.Permission).Where(w =>w.Id != 0).ToListAsync();
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
      return await Task.FromResult<(IList<Api> list,  int total)>((list, count));
    }
  }
}