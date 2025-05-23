using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   权限菜单领域服务
/// </summary>
public class MenuService
{
  private readonly IIdGenerator _idGenerator;
  private readonly IMenuRepositories _menuRepositories;

  /// <summary>
  ///   权限菜单服务
  /// </summary>
  /// <param name="menuRepositories"></param>
  /// <param name="idGenerator"></param>
  public MenuService(IMenuRepositories menuRepositories, IIdGenerator idGenerator)
  {
    _menuRepositories = menuRepositories;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   获取权限菜单
  /// </summary>
  /// <param name="id"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<Result<PermissionMenu>> Get(long id, long? tenancyId = null)
  {
    var permissionMenu = await _menuRepositories.GetPermissionMenuAsync(id, tenancyId);
    if (permissionMenu == null)
      return Result<PermissionMenu>.ReFailure(ResultCodes.PermissionMenuNotExist);
    return Result<PermissionMenu>.ReSuccess(permissionMenu);
  }

  /// <summary>
  ///   获取所有权限菜单集合
  /// </summary>
  /// <returns></returns>
  public async Task<ResultList<PermissionMenu>> GetList()
  {
    var list = await _menuRepositories.GetEntities(f => f.Id != 0);
    if (list == null)
      return ResultList<PermissionMenu>.ReFailure(ResultCodes.PermissionMenuNotExist);
    return ResultList<PermissionMenu>.ReSuccess(list.ToList());
  }

  /// <summary>
  ///   获取权限菜单分页列表
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="permissionId"></param>
  /// <param name="title"></param>
  /// <param name="menuUrl"></param>
  /// <param name="tenancyId"></param>
  /// <returns></returns>
  public async Task<(IList<PermissionMenu> list, int total)> GetList(int pageNo, int pageSize, string permissionId = "",
    string title = "", string menuUrl = "", long? tenancyId = null)
  {
    return await _menuRepositories.GetEntitiesForPaging(pageNo, pageSize, permissionId, title, menuUrl,
      tenancyId);
  }

  /// <summary>
  ///   创建权限菜单
  /// </summary>
  /// <param name="permissionMenu"></param>
  /// <returns></returns>
  public async Task<Result> Create(PermissionMenu permissionMenu)
  {
    // 判断权限菜单标题或地址是否重复了
    if (await _menuRepositories.GetEntity(f => f.TenancyId == permissionMenu.TenancyId &&
                                               (f.Title.Equals(permissionMenu.Title) ||
                                                f.MenuUrl.Equals(permissionMenu.MenuUrl))) != null)
      return Result.ReFailure(ResultCodes.PermissionMenuTitleOrUrlExist);
    permissionMenu.SetId(_idGenerator.GenId());
    // 添加权限菜单
    var isAdd = await _menuRepositories.Add(permissionMenu);
    if (!isAdd)
      return Result.ReFailure(ResultCodes.PermissionMenuCreateError);
    return Result.ReSuccess();
  }

  /// <summary>
  ///   修改权限菜单
  /// </summary>
  /// <param name="permissionMenu"></param>
  /// <returns></returns>
  public async Task<Result> Modify(PermissionMenu permissionMenu)
  {
    if (await _menuRepositories.GetEntity(f =>
          (f.Id != permissionMenu.Id && f.TenancyId == permissionMenu.TenancyId &&
           f.Title.Equals(permissionMenu.Title)) ||
          (f.Id != permissionMenu.Id && f.MenuUrl.Equals(permissionMenu.MenuUrl))) != null)
      return Result.ReFailure(ResultCodes.PermissionMenuTitleOrUrlExist);
    var isUpdate = await _menuRepositories.Update(permissionMenu);
    if (!isUpdate) return Result.ReFailure(ResultCodes.PermissionMenuUpdateError);

    return Result.ReSuccess();
  }

  /// <summary>
  ///   删除权限菜单
  /// </summary>
  /// <param name="permissionMenu"></param>
  /// <returns></returns>
  public async Task<Result> Delete(PermissionMenu permissionMenu)
  {
    var isDelete = await _menuRepositories.Delete(permissionMenu);
    if (!isDelete) return Result.ReFailure(ResultCodes.PermissionMenuDeleteError);

    return Result.ReSuccess();
  }
}