using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   权限服务
/// </summary>
public class PermissionService
{
  /// <summary>
  ///   雪花算法id
  /// </summary>
  private readonly IIdGenerator _idGenerator;

  // 权限仓储
  private readonly IPermissionsRepository _permissionsRepository;

  /// <summary>
  ///   权限服务
  /// </summary>
  /// <param name="permissionsRepository"></param>
  /// <param name="idGenerator"></param>
  public PermissionService(IPermissionsRepository permissionsRepository, IIdGenerator idGenerator)
  {
    _permissionsRepository = permissionsRepository;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取权限详情
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<Permission>> Get(long id, long? tenancyId = null)
  {
    var permission = await _permissionsRepository.GetAsync(id, tenancyId);
    if (permission == null)
      return Result<Permission>.ReFailure(ResultCodes.PermissionNotExist);
    return Result<Permission>.ReSuccess(permission);
  }

  /// <summary>
  ///   通过 id集合获取权限集合
  /// </summary>
  /// <param name="permissionList"></param>
  /// <returns>返回权限集合</returns>
  public async Task<ResultList<Permission>> GetPermissionListAsync(List<long> permissionList)
  {
    var list = await _permissionsRepository.GetListAsync(permissionList);
    if (list.Count == 0)
      return ResultList<Permission>.ReFailure(ResultCodes.PermissionNotExist);
    return ResultList<Permission>.ReSuccess(list);
  }

  /// <summary>
  ///   获取权限集合
  /// </summary>
  /// <returns></returns>
  public async Task<ResultList<Permission>> GetList(long? tenancyId, bool isSuperAdmin = false)
  {
    if (tenancyId != null)
    {
      if (isSuperAdmin)
      {
        var list = await _permissionsRepository.GetEntities(f => f.Id != 0);
        return ResultList<Permission>.ReSuccess(list.ToList());
      }
      else
      {
        var list = await _permissionsRepository.GetEntities(f =>
          f.Id != 0 && f.IsSystem != null && f.IsSystem != 1);
        return ResultList<Permission>.ReSuccess(list.ToList());
      }
    }

    if (isSuperAdmin)
    {
      var list = await _permissionsRepository.GetEntities(f => f.Id != 0);
      return ResultList<Permission>.ReSuccess(list.ToList());
    }
    else
    {
      var list = await _permissionsRepository.GetEntities(f =>
        f.Id != 0 && f.IsSystem != null && f.IsSystem != 1);
      return ResultList<Permission>.ReSuccess(list.ToList());
    }
  }

  /// <summary>
  ///   获取权限分页列表
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="code"></param>
  /// <param name="name"></param>
  /// <param name="type"></param>
  /// <param name="isSys"></param>
  /// <param name="status"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<(IList<Permission> list, int total)> GetList(int pageNo, int pageSize, string code = "",
    string name = "", uint? type = null, uint? isSys = null, uint? status = null, long? tenancyId = null)
  {
    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name) && type != null &&
        status != null && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Code.Contains(code) && f.Name.Contains(name) && f.Type == type && f.Enable == status &&
               f.TenancyId == tenancyId);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name) && type != null &&
        status != null && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Name.Contains(name) && f.Type == type && f.IsSystem != 1 && f.Enable == status &&
               f.TenancyId == tenancyId);
      return (list, total);
    }

    if (type != null &&
        status != null && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Type == type && f.IsSystem != 1 && f.Enable == status && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (
      status != null && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.IsSystem != 1 && f.Enable == status && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (
      !string.IsNullOrEmpty(code) && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Code.Contains(code) && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (
      !string.IsNullOrEmpty(name) && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Name.Contains(name) && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (type != null && tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Type == type && f.TenancyId == tenancyId);
      return (list, total);
    }

    if (tenancyId != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.TenancyId == tenancyId);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(code) && !string.IsNullOrEmpty(name) && type != null && isSys != null &&
        status != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Code.Contains(code) && f.Name.Contains(name) && f.Type == type && f.IsSystem == isSys &&
               f.Enable == status);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(name) && type != null && isSys != null &&
        status != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Name.Contains(name) && f.Type == type && f.IsSystem == isSys && f.Enable == status);
      return (list, total);
    }

    if (type != null && isSys != null &&
        status != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.Type == type && f.IsSystem == isSys && f.Enable == status);
      return (list, total);
    }

    if (isSys != null &&
        status != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize,
          f => f.IsSystem == isSys && f.Enable == status);
      return (list, total);
    }

    if (
      status != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.Enable == status);
      return (list, total);
    }

    if (
      !string.IsNullOrEmpty(code))
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.Code.Contains(code));
      return (list, total);
    }

    if (
      !string.IsNullOrEmpty(name))
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.Name.Contains(name));
      return (list, total);
    }

    if (type != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.Type == type);
      return (list, total);
    }

    if (isSys != null)
    {
      var (list, total) =
        await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.IsSystem == isSys);
      return (list, total);
    }

    var (data, totalCount) =
      await _permissionsRepository.GetEntitiesForPaging(pageNo, pageSize, f => f.Id != 0);
    return (data, totalCount);
  }

  /// <summary>
  ///   添加权限
  /// </summary>
  /// <param name="permission"></param>
  /// <returns></returns>
  public async Task<Result> Create(Permission permission)
  {
    if (await _permissionsRepository.GetEntity(f =>
          f.TenancyId == permission.TenancyId &&
          (f.Code.Equals(permission.Code) || f.Name.Equals(permission.Name))) !=
        null)
      return Result.ReFailure(ResultCodes.PermissionNameOrCodeExist);
    permission.SetId(_idGenerator.GenId());
    var isAdd = await _permissionsRepository.Add(permission);
    if (!isAdd) return Result.ReFailure(ResultCodes.PermissionCreateError);
    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改权限
  /// </summary>
  /// <param name="permission"></param>
  /// <returns></returns>
  public async Task<Result> Modify(Permission permission)
  {
    // 判断是否存在相同的 权限code和权限名称
    if (await _permissionsRepository.GetEntity(f =>
          f.Id != permission.Id && f.TenancyId == permission.TenancyId &&
          (f.Name.Equals(permission.Name) || f.Code.Equals(permission.Code))) != null)
      return Result.ReFailure(ResultCodes.PermissionNameOrCodeExist);
    var isUpdate = await _permissionsRepository.Update(permission);
    if (!isUpdate) return Result.ReFailure(ResultCodes.PermissionUpdateError);
    return Result.ReSuccess();
  }

  /// <summary>
  ///   删除权限
  /// </summary>
  /// <param name="permission"></param>
  /// <returns></returns>
  public async Task<Result> Delete(Permission permission)
  {
    var isDelete = await _permissionsRepository.Delete(permission);
    if (!isDelete) return Result.ReFailure(ResultCodes.PermissionDeleteError);
    return Result.ReSuccess();
  }
}