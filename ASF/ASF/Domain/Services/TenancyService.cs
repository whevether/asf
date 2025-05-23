using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   租户服务
/// </summary>
public class TenancyService
{
  private readonly IIdGenerator _idGenerator;
  private readonly ITenancyRepository _repository;

  /// <summary>
  ///   租户服务
  /// </summary>
  /// <param name="repository"></param>
  /// <param name="idGenerator"></param>
  public TenancyService(ITenancyRepository repository, IIdGenerator idGenerator)
  {
    _repository = repository;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取租户详情
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public async Task<Result<Tenancy>> Get(long id)
  {
    var tenancy = await _repository.GetAsync(id);
    if (tenancy == null)
      return Result<Tenancy>.ReFailure(ResultCodes.TenancyNotExist);
    if (tenancy.Status != null && (EnabledType)tenancy.Status == EnabledType.Disabled)
      return Result<Tenancy>.ReFailure(ResultCodes.TenancyDisabled);
    if (tenancy.IsDeleted != null && (Status)tenancy.IsDeleted == Status.Yes)
      return Result<Tenancy>.ReFailure(ResultCodes.TenancyIsDelete);
    // 判断租户是否被禁用
    // if ((EnabledType)tenancy.Status == EnabledType.Disabled)
    // 	return Result<Tenancy>.ReFailure(ResultCodes.TenancyDisabled);
    return Result<Tenancy>.ReSuccess(tenancy);
  }

  /// <summary>
  ///   获取租户列表
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="name"></param>
  /// <param name="status">租户状态</param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<(IList<Tenancy> list, int total)> GetList(int pageNo, int pageSize, string name = "",
    uint? status = null, long? tenancyId = null)
  {
    if (!string.IsNullOrEmpty(name) && status != null && tenancyId != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Equals(name) && f.Status == status && (Status)f.IsDeleted == Status.No && f.Id == tenancyId);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name) && tenancyId != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Equals(name) && (Status)f.IsDeleted == Status.No && f.Id == tenancyId);
      return (list, total);
    }

    if (status != null && tenancyId != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Status == status && (Status)f.IsDeleted == Status.No && f.Id == tenancyId);
      return (list, total);
    }

    if (tenancyId != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Id != 0 && (Status)f.IsDeleted == Status.No && f.Id == tenancyId);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name) && status != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Equals(name) && f.Status == status && (Status)f.IsDeleted == Status.No);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name))
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Equals(name) && (Status)f.IsDeleted == Status.No);
      return (list, total);
    }

    if (status != null)
    {
      var (list, total) = await _repository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Status == status && (Status)f.IsDeleted == Status.No);
      return (list, total);
    }

    var (data, totalCount) =
      await _repository.GetEntitiesForPaging(pageNo, pageSize, f => f.Id != 0 && (Status)f.IsDeleted == Status.No);
    return (data, totalCount);
  }

  /// <summary>
  ///   获取租户列表集合
  /// </summary>
  /// <returns></returns>
  public async Task<ResultList<Tenancy>> GetList()
  {
    var list = await _repository.GetEntities(f => f.Id != 0 && (Status)f.IsDeleted == Status.No);
    if (list == null)
      return ResultList<Tenancy>.ReFailure(ResultCodes.TenancyNotExist);
    return ResultList<Tenancy>.ReSuccess(list.ToList());
  }

  /// <summary>
  ///   创建租户
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public async Task<Result> Create(Tenancy request)
  {
    if (await _repository.GetEntity(f => f.Name.Equals(request.Name)) != null)
      return Result.ReFailure(ResultCodes.TenancyNameExist);
    request.SetId(_idGenerator.GenId());
    var isAdd = await _repository.Add(request);
    if (!isAdd) return Result.ReFailure(ResultCodes.TenancyCreateFailure);
    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改租户
  /// </summary>
  /// <param name="request"></param>
  /// <returns></returns>
  public async Task<Result> Modify(Tenancy request)
  {
    if (await _repository.GetEntity(f => f.Id != request.Id && f.Name.Equals(request.Name)) != null)
      return Result.ReFailure(ResultCodes.TenancyNameExist);
    var isUpdate = await _repository.Update(request);
    if (!isUpdate) return Result.ReFailure(ResultCodes.TenancyModifyFailure);
    return Result.ReSuccess();
  }
}