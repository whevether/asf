using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ASF.EntityFramework.Repository;

public class AccountsRepository : Repositories<Account>, IAccountsRepository
{
  public AccountsRepository(RepositoryContext context) : base(context)
  {
  }

  /// <summary>
  ///   获取账户列表
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="username"></param>
  /// <param name="telPhone"></param>
  /// <param name="email"></param>
  /// <param name="sex"></param>
  /// <param name="status"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<(IList<Account> list, int total)> GetList(int pageNo, int pageSize, string username,
    string telPhone, string email, int? sex,
    uint? status, long? tenancyId = null)
  {
    var queryable = GetDbContext().Account
      .Include("Department")
      .Include("AccountRole.Role")
      .Include("AccountPost.Post")
      .AsSplitQuery()
      .Where(f => f.IsDeleted != 1);

    if (tenancyId != null)
      queryable = queryable.Where(f => f.TenancyId == tenancyId);
    if (!string.IsNullOrEmpty(username))
      queryable = queryable.Where(f => f.Username.Equals(username));
    if (!string.IsNullOrEmpty(telPhone))
      queryable = queryable.Where(f => f.TelPhone.Equals(telPhone));
    if (!string.IsNullOrEmpty(email))
      queryable = queryable.Where(f => f.Email.Equals(email));
    if (sex != null)
      queryable = queryable.Where(f => f.Sex == sex);
    if (status != null)
      queryable = queryable.Where(f => f.Status == status);

    var count = await queryable.CountAsync();
    var p = pageNo == 0 ? 1 : pageNo;
    var c = pageSize == 0 ? count : pageSize;
    var list = await queryable
      .Skip((p - 1) * c)
      .Take(c)
      .ToListAsync();
    return (list, count);
  }

  /// <summary>
  ///   通过用户id获取用户角色权限信息
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId">租户id</param>
  /// <returns>返回用户部门信息以及角色权限信息</returns>
  public async Task<Account> GetAccountAndRoleAndPermissionAsync(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var a = await GetDbContext().Account
        .Include("Department.DepartmentRole.Role.PermissionRole.Permission")
        .Include("AccountRole.Role.PermissionRole.Permission").OrderBy(f => f.Id)
        .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
      return await Task.FromResult(a);
    }

    var account = await GetDbContext().Account
      .Include("Department.DepartmentRole.Role.PermissionRole.Permission")
      .Include("AccountRole.Role.PermissionRole.Permission").OrderBy(f => f.Id)
      .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id);
    return await Task.FromResult(account);
  }

  /// <summary>
  ///   获取账户对应岗位和部门
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetAccountByPostAsync(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var a = await GetDbContext().Account.Include("AccountPost.Post").AsSplitQuery().OrderBy(f => f.Id)
        .FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
      return await Task.FromResult(a);
    }

    var account = await GetDbContext().Account.Include("AccountPost.Post").AsSplitQuery().OrderBy(f => f.Id)
      .FirstOrDefaultAsync(f => f.Id == id);
    return await Task.FromResult(account);
  }

  /// <summary>
  ///   获取账户对应岗位与部门以及角色权限
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetAccountByPostAndRoleAsync(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var a = await GetDbContext().Account
        .Include("Department.DepartmentRole.Role")
        .Include("AccountRole.Role")
        .Include("AccountPost.Post")
        .Include("Tenancys").OrderBy(f => f.Id)
        .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
      return await Task.FromResult(a);
    }

    var account = await GetDbContext().Account
      .Include("Department.DepartmentRole.Role")
      .Include("AccountRole.Role").OrderBy(f => f.Id)
      .Include("AccountPost.Post")
      .Include("Tenancys")
      .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id);
    return await Task.FromResult(account);
  }

  /// <summary>
  ///   获取账户对应角色
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetAccountByRole(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var a = await GetDbContext().Account
        .Include("AccountRole.Role").Include("Department.DepartmentRole.Role").OrderBy(f => f.Id)
        .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id && f.TenancyId == tenancyId);
      return await Task.FromResult(a);
    }

    var account = await GetDbContext().Account
      .Include("AccountRole.Role").Include("Department.DepartmentRole.Role").OrderBy(f => f.Id)
      .AsSplitQuery().FirstOrDefaultAsync(f => f.Id == id);
    return await Task.FromResult(account);
  }

  /// <summary>
  ///   通过用户名获取账户信息
  /// </summary>
  /// <param name="username"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetByUsernameAsync(string username, long tenancyId)
  {
    var account = await GetDbContext().Account.Include("Department.DepartmentRole.Role").Include("AccountRole.Role")
      .OrderBy(f => f.Id).AsSplitQuery()
      .FirstOrDefaultAsync(f => f.Username.Equals(username) && f.TenancyId == tenancyId);

    return await Task.FromResult(account);
  }

  /// <summary>
  ///   通过手机号码找到账号
  /// </summary>
  /// <param name="phone"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetByPhoneAsync(string phone, long tenancyId)
  {
    var account = await GetDbContext().Account.Include("Department.DepartmentRole.Role").Include("AccountRole.Role")
      .OrderBy(f => f.Id).AsSplitQuery().FirstOrDefaultAsync(f => f.TelPhone.Equals(phone) && f.TenancyId == tenancyId);
    return await Task.FromResult(account);
  }

  /// <summary>
  ///   通过邮箱找到账号
  /// </summary>
  /// <param name="email"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Account> GetByEamilAsync(string email, long tenancyId)
  {
    var account = await GetDbContext().Account.Include("Department.DepartmentRole.Role").Include("AccountRole.Role")
      .OrderBy(f => f.Id).AsSplitQuery().FirstOrDefaultAsync(f => f.Email.Equals(email) && f.TenancyId == tenancyId);
    return await Task.FromResult(account);
  }
}
