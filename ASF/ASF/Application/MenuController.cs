using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Application.DTO;
using ASF.Domain;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application;

/// <summary>
///   权限菜单控制器
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class MenuController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IServiceProvider _serviceProvider;

  /// <summary>
  ///   菜单控制器
  /// </summary>
  /// <param name="serviceProvider"></param>
  /// <param name="mapper"></param>
  public MenuController(IServiceProvider serviceProvider, IMapper mapper)
  {
    _serviceProvider = serviceProvider;
    _mapper = mapper;
  }

  /// <summary>
  ///   获取权限菜单分页列表
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultPagedList<PermissionMenuResponseDto>> GetList(
    [FromQuery] PermissionMenuListRequestDto dto)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var (list, total) = await _serviceProvider.GetRequiredService<MenuService>()
      .GetList(dto.PageNo, dto.PageSize, dto.PermissionId, dto.Title, dto.MenuUrl, tenancyId);
    return ResultPagedList<PermissionMenuResponseDto>.ReSuccess(_mapper.Map<List<PermissionMenuResponseDto>>(list),
      total);
  }

  /// <summary>
  ///   获取权限菜单详情
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<Result<PermissionMenuResponseDto>> Details([FromQuery] long id)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await _serviceProvider.GetRequiredService<MenuService>().Get(id, tenancyId);
    if (!result.Success)
      return Result<PermissionMenuResponseDto>.ReFailure(result.Message, result.Status);
    return Result<PermissionMenuResponseDto>.ReSuccess(_mapper.Map<PermissionMenuResponseDto>(result.Data));
  }

  /// <summary>
  ///   创建权限菜单
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> Create([FromBody] PermissionMenuCreateRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? long.Parse(dto.TenancyId)
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var permissionMenu = _mapper.Map<PermissionMenu>(dto);
    permissionMenu.TenancyId = tenancyId;
    if (permissionMenu.IsSystem != null && (Status)permissionMenu.IsSystem == Status.Yes &&
        !HttpContext.User.IsSuperRole())
      return Result.ReFailure(ResultCodes.PermissionSystemNotCreate);
    return await _serviceProvider.GetRequiredService<MenuService>().Create(permissionMenu);
  }

  /// <summary>
  ///   修改权限菜单
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> Modify([FromBody] PermissionMenuModifyRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var server = _serviceProvider.GetRequiredService<MenuService>();
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    if (result.Data.IsSystem != null && (Status)result.Data.IsSystem == Status.Yes &&
        !HttpContext.User.IsSuperRole())
      return Result.ReFailure(ResultCodes.PermissionSystemNotModify);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    return await _serviceProvider.GetRequiredService<MenuService>().Modify(_mapper.Map(dto, result.Data));
  }

  /// <summary>
  ///   修改菜单显示状态
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> ModifyHidden([FromBody] ModifyStatusRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var server = _serviceProvider.GetRequiredService<MenuService>();
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    if (result.Data.IsSystem != null && (Status)result.Data.IsSystem == Status.Yes &&
        !HttpContext.User.IsSuperRole())
      return Result.ReFailure(ResultCodes.PermissionSystemNotModify);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    result.Data.MenuHidden = dto.Status;
    return await _serviceProvider.GetRequiredService<MenuService>().Modify(result.Data);
  }

  /// <summary>
  ///   删除权限菜单
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpPost("{id}")]
  public async Task<Result> Delete([FromRoute] string id)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var server = _serviceProvider.GetRequiredService<MenuService>();
    var result = await server.Get(long.Parse(id), tenancyId);
    if (!result.Success)
      return result;
    if (result.Data.IsSystem != null && (Status)result.Data.IsSystem == Status.Yes &&
        !HttpContext.User.IsSuperRole())
      return Result.ReFailure(ResultCodes.PermissionSysDeleteError);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    return await server.Delete(result.Data);
  }
}