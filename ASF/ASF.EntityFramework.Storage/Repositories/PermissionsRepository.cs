using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository;

public class PermissionsRepository : Repositories<Permission>, IPermissionsRepository
{
  public PermissionsRepository(RepositoryContext context) : base(context)
  {
  }

  /// <summary>
  ///   根据id获取对应权限
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Permission> GetAsync(long id, long? tenancyId = null)
  {
    // var cc = base.GetDbContext().Accounts.Include("AccountPost.Post").Include("Department.DepartmentRole.Role.PermissionRole.Permission").ToList();
    if (tenancyId != null)
      return await GetDbContext().Permission.Include("PermissionMenus").Include("Apis")
        .FirstOrDefaultAsync(x => x.Id == id && x.TenancyId == tenancyId);
    return await GetDbContext().Permission.Include("PermissionMenus").Include("Apis")
      .FirstOrDefaultAsync(x => x.Id == id);
  }

  /// <summary>
  ///   根据权限id集合获取权限集合
  /// </summary>
  /// <param name="ids"></param>
  /// <returns></returns>
  public async Task<List<Permission>> GetListAsync(List<long> ids)
  {
    var list = (from p in await GetDbContext().Permission.Include("PermissionMenus").Include("Apis").ToListAsync()
      from l in ids
      // where (p.Id == l && (!p.Code.Equals("asf_openapi") && p.Type != 3))
      where p.Id == l
      select p).ToList();
    return await Task.FromResult(list);
  }
}