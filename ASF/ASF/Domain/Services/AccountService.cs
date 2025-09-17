using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   账户服务
/// </summary>
public class AccountService
{
  //账户仓储
  private readonly IAccountsRepository _accountsRepository;

  // 雪花算法id
  private readonly IIdGenerator _idGenerator;

  /// <summary>
  ///   账户服务
  /// </summary>
  /// <param name="accountsRepository"></param>
  /// <param name="idGenerator"></param>
  public AccountService(IAccountsRepository accountsRepository, IIdGenerator idGenerator)
  {
    _accountsRepository = accountsRepository;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取账户登录权限信息
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="tenancyId">租户id</param>
  /// <returns></returns>
  public async Task<Result<Account>> GetAccountInfo(long uid, long? tenancyId = null)
  {
    var account = await _accountsRepository.GetAccountAndRoleAndPermissionAsync(uid, tenancyId);
    if (account == null)
      return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
    if (account.IsDeleted != null && (Status)account.IsDeleted == Status.Yes)
      return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
    return Result<Account>.ReSuccess(account);
  }

  /// <summary>
  ///   获取账户基本信息
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Account>> Get(long uid, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var a = await _accountsRepository.GetEntity(f => f.Id == uid && f.TenancyId == tenancyId);
      if (a == null)
        return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
      if (a.IsDeleted != null && (Status)a.IsDeleted == Status.Yes)
        return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
      return Result<Account>.ReSuccess(a);
    }

    var account = await _accountsRepository.GetEntity(f => f.Id == uid);
    if (account == null)
      return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
    if (account.IsDeleted != null && (Status)account.IsDeleted == Status.Yes)
      return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
    return Result<Account>.ReSuccess(account);
  }

  /// <summary>
  ///   获取账户对应岗位和部门
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Account>> GetAccountByPostAsync(long uid, long? tenancyId = null)
  {
    var account = await _accountsRepository.GetAccountByPostAsync(uid, tenancyId);
    if (account == null)
      return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
    if (account.IsDeleted != null && (Status)account.IsDeleted == Status.Yes)
      return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
    return Result<Account>.ReSuccess(account);
  }

  /// <summary>
  ///   获取账户对应角色
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Account>> GetAccountByRole(long uid, long? tenancyId = null)
  {
    var account = await _accountsRepository.GetAccountByRole(uid, tenancyId);
    if (account == null)
      return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
    if (account.IsDeleted != null && (Status)account.IsDeleted == Status.Yes)
      return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
    return Result<Account>.ReSuccess(account);
  }

  /// <summary>
  ///   获取账户对应 角色权限以及部门。租户，岗位信息
  /// </summary>
  /// <param name="uid"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Account>> GetDetails(long uid, long? tenancyId = null)
  {
    var account = await _accountsRepository.GetAccountByPostAndRoleAsync(uid, tenancyId);
    if (account == null)
      return Result<Account>.ReFailure(ResultCodes.AccountNotExist);
    if (account.IsDeleted != null && (Status)account.IsDeleted == Status.Yes)
      return Result<Account>.ReFailure(ResultCodes.AccountUnavailable);
    return Result<Account>.ReSuccess(account);
  }

  /// <summary>
  ///   获取账户分页列表
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
    string telPhone, string email, int? sex, uint? status, long? tenancyId = null)
  {
    return await _accountsRepository.GetList(pageNo, pageSize, username, telPhone, email, sex, status, tenancyId);
  }

  /// <summary>
  ///   创建账户
  /// </summary>
  /// <param name="account"></param>
  /// <returns></returns>
  public async Task<Result> Create(Account account)
  {
    if (await _accountsRepository.GetEntity(f =>
          f.TenancyId == account.TenancyId &&
          (f.Username.Equals(account.Username) || (!string.IsNullOrEmpty(account.Email)&&f.Email.Equals(account.Email)) ||
           (!string.IsNullOrEmpty(account.TelPhone) && f.TelPhone.Equals(account.TelPhone)))) != null)
      return Result.ReFailure(ResultCodes.AccountExist);
    account.SetId(_idGenerator.GenId());
    var isAdd = await _accountsRepository.Add(account);
    if (!isAdd)
      return Result.ReFailure(ResultCodes.AccountCreate);
    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改账户
  /// </summary>
  /// <param name="account"></param>
  /// <param name="dic">返回值字典</param>
  /// <returns></returns>
  public async Task<Result> Modify(Account account, string dic = "default")
  {
    if (dic.Equals("default") && await _accountsRepository.GetEntity(f =>
          f.Id != account.Id && f.TenancyId == account.TenancyId && (f.Username.Equals(account.Username) ||
                                                                     f.Email.Equals(account.Email) ||
                                                                     f.TelPhone.Equals(account.TelPhone))) !=
        null)
      return Result.ReFailure(ResultCodes.AccountExist);
    if (dic.Equals("telphone") && await _accountsRepository.GetEntity(f =>
          f.Id != account.Id && f.TenancyId == account.TenancyId && f.TelPhone.Equals(account.TelPhone)) != null)
      return Result.ReFailure(ResultCodes.AccountExistTelPhoneError);
    if (dic.Equals("email") && await _accountsRepository.GetEntity(f =>
          f.Id != account.Id && f.TenancyId == account.TenancyId && f.Email.Equals(account.Email)) != null)
      return Result.ReFailure(ResultCodes.AccountExistEmailError);
    if (dic.Equals("username") && await _accountsRepository.GetEntity(f =>
          f.Id != account.Id && f.TenancyId == account.TenancyId && f.Username.Equals(account.Username)) != null)
      return Result.ReFailure(ResultCodes.AccountExistUserNameError);
    var isUpdate = await _accountsRepository.Update(account);
    if (!isUpdate)
      return Result.ReFailure(ResultCodes.AccountUpdateError);
    return Result.ReSuccess();
  }
}
