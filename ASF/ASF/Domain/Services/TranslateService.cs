using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   多语言服务
/// </summary>
public class TranslateService
{
  private readonly IIdGenerator _idGenerator;
  private readonly ITranslateRepositories _translateRepositories;

  /// <summary>
  ///   多语言服务
  /// </summary>
  /// <param name="translateRepositories"></param>
  /// <param name="idGenerator"></param>
  public TranslateService(ITranslateRepositories translateRepositories, IIdGenerator idGenerator)
  {
    _translateRepositories = translateRepositories;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取多语言
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Translate>> Get(long id, long? tenancyId = null)
  {
    if (tenancyId != null)
    {
      var t = await _translateRepositories.GetEntity(f => f.Id == id && f.TenancyId == tenancyId);
      if (t == null)
        return Result<Translate>.ReFailure(ResultCodes.TranslateNotExist);
      return Result<Translate>.ReSuccess(t);
    }

    var translate = await _translateRepositories.GetEntity(f => f.Id == id);
    if (translate == null)
      return Result<Translate>.ReFailure(ResultCodes.TranslateNotExist);
    return Result<Translate>.ReSuccess(translate);
  }

  /// <summary>
  ///   获取多语言分页
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="name"></param>
  /// <param name="tenancyId">租户id</param>
  /// <returns></returns>
  public async Task<(IList<Translate> list, int total)> GetList(int pageNo, int pageSize, string name,
    long? tenancyId = null)
  {
    if (!string.IsNullOrEmpty(name) && tenancyId != null)
    {
      var (list, total) = await _translateRepositories.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Name.Equals(name) && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (tenancyId != null)
    {
      var (list, total) =
        await _translateRepositories.GetEntitiesForPaging(pageNo, pageSize, f => f.TenancyId == tenancyId);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name))
    {
      var (list, total) = await _translateRepositories.GetEntitiesForPaging(pageNo, pageSize, f => f.Name.Equals(name));
      return (list, total);
    }

    var (data, totalCount) = await _translateRepositories.GetEntitiesForPaging(pageNo, pageSize, f => f.Id != 0);
    return (data, totalCount);
  }

  /// <summary>
  ///   获取多语言列表
  /// </summary>
  /// <param name="isAdmin">是否为管理后台</param>
  /// <returns></returns>
  public async Task<ResultList<Translate>> GetList(bool isAdmin = false)
  {
    var b = Convert.ToUInt32(isAdmin);
    var list = await _translateRepositories.GetEntities(f => f.IsAdmin == b);
    if (list == null)
      return ResultList<Translate>.ReFailure(ResultCodes.TranslateNotExist);
    return ResultList<Translate>.ReSuccess(list.ToList());
  }

  /// <summary>
  ///   添加多语言
  /// </summary>
  /// <param name="translate"></param>
  /// <returns></returns>
  public async Task<Result> Create(Translate translate)
  {
    if (await _translateRepositories.GetEntity(f =>
          f.TenancyId == translate.TenancyId && f.Value.Equals(translate.Value)) != null)
      return Result.ReFailure(ResultCodes.TranslateNameExist);
    translate.SetId(_idGenerator.GenId());
    var isAdd = await _translateRepositories.Add(translate);
    if (!isAdd) return Result.ReFailure(ResultCodes.TranslateCreateError);

    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改多语言
  /// </summary>
  /// <param name="translate"></param>
  /// <returns></returns>
  public async Task<Result> Modify(Translate translate)
  {
    if (await _translateRepositories.GetEntity(f =>
          f.Id != translate.Id && f.TenancyId == translate.TenancyId && f.Value.Equals(translate.Value)) != null)
      return Result.ReFailure(ResultCodes.TranslateNameExist);
    var isUpdate = await _translateRepositories.Update(translate);
    if (!isUpdate) return Result.ReFailure(ResultCodes.TranslateUpdateError);

    return Result.ReSuccess();
  }

  /// <summary>
  ///   硬 删除多语言
  /// </summary>
  /// <param name="translate"></param>
  /// <returns></returns>
  public async Task<Result> Delete(Translate translate)
  {
    var isDelete = await _translateRepositories.Delete(translate);
    if (!isDelete) return Result.ReFailure(ResultCodes.TranslateDeleteError);

    return Result.ReSuccess();
  }
}