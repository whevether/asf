using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Entities;

namespace ASF.Infrastructure.Repositories;

/// <summary>
///   账户仓储
/// </summary>
public interface IAccountsRepository : IRepositories<Account>
{
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
	Task<(IList<Account> list, int total)> GetList(int pageNo, int pageSize, string username, string telPhone,
    string email, int? sex,
    uint? status, long? tenancyId = null);

	/// <summary>
	///   通过用户id获取用户角色权限信息
	/// </summary>
	/// <param name="id"></param>
	/// <param name="tenancyId">租户id</param>
	/// <returns>返回用户部门信息以及角色权限信息</returns>
	Task<Account> GetAccountAndRoleAndPermissionAsync(long id, long? tenancyId = null);

	/// <summary>
	///   获取账户对应岗位与部门
	/// </summary>
	/// <param name="id"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetAccountByPostAsync(long id, long? tenancyId = null);

	/// <summary>
	///   获取账户对应岗位与部门以及角色权限
	/// </summary>
	/// <param name="id"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetAccountByPostAndRoleAsync(long id, long? tenancyId = null);

	/// <summary>
	///   获取账户对应角色
	/// </summary>
	/// <param name="id"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetAccountByRole(long id, long? tenancyId = null);

	/// <summary>
	///   通过用户名获取账户信息
	/// </summary>
	/// <param name="username"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetByUsernameAsync(string username, long tenancyId);

	/// <summary>
	///   通过手机号码找到账号
	/// </summary>
	/// <param name="phone"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetByPhoneAsync(string phone, long tenancyId);

	/// <summary>
	///   通过邮箱找到账号
	/// </summary>
	/// <param name="email"></param>
	/// <param name="tenancyId"></param>
	/// <returns></returns>
	Task<Account> GetByEamilAsync(string email, long tenancyId);
}