using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository;

/// <summary>
///   api仓储
/// </summary>
public class ApiRepository : Repositories<Api>, IApiRepository
{
  public ApiRepository(RepositoryContext context) : base(context)
  {
  }

  /// <summary>
  ///   获取权限功能详情
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Api> GetApiAsync(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
      return await GetDbContext().Api.Include(f => f.Permission)
        .FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
    return await GetDbContext().Api.Include(f => f.Permission).FirstOrDefaultAsync(f => f.Id == id);
  }

  /// <summary>
  ///   获取api列表
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
  public async Task<(IList<Api> list, int total)> GetEntitiesForPaging(int pageNo, int pageSize,
    string permissionId = "", uint? type = null, uint? status = null,
    string name = "", string httpMethod = "", string path = "", long? tenancyId = null)
  {
    var queryable = GetDbContext().Api.Include(f => f.Permission).AsQueryable();
    if (tenancyId != null)
      queryable = queryable.Where(w => w.TenancyId == tenancyId);
    if (!string.IsNullOrEmpty(permissionId))
      queryable = queryable.Where(w => w.PermissionId.ToString().Equals(permissionId));
    if (type != null)
      queryable = queryable.Where(w => w.Type == type);
    if (status != null)
      queryable = queryable.Where(w => w.Status == status);
    if (!string.IsNullOrEmpty(name))
      queryable = queryable.Where(w => w.Name.Contains(name));
    if (!string.IsNullOrEmpty(httpMethod))
      queryable = queryable.Where(w => w.HttpMethods.Equals(httpMethod));
    if (!string.IsNullOrEmpty(path))
      queryable = queryable.Where(w => w.Path.Contains(path));

    var count = await queryable.CountAsync();
    var p = pageNo == 0 ? 1 : pageNo;
    var c = pageSize == 0 ? count : pageSize;
    var list = await queryable
      .Skip((p - 1) * c)
      .Take(c)
      .ToListAsync();
    return (list, count);
  }
}
