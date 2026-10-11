using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Application.DTO;
using ASF.Application.DTO.Tenancy;
using ASF.Domain;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using Microsoft.Extensions.Localization;
using ASF.Resources;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASF.Application;

/// <summary>
///   租户控制器
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class TenancyController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IStringLocalizer<SharedResource> _stringLocalizer;
  private readonly TenancyService _tenancyService;

  /// <summary>
  ///   租户控制器
  /// </summary>
  public TenancyController(TenancyService tenancyService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
  {
    _tenancyService = tenancyService;
    _mapper = mapper;
    _stringLocalizer = stringLocalizer;
  }

  /// <summary>
  ///   获取租户分页列表
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultPagedList<TenancyResponseDto>> GetList([FromQuery] TenancyListRequestDto dto)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var (list, total) = await _tenancyService
      .GetList(dto.PageNo, dto.PageSize, dto.Name, dto.Status, tenancyId);
    return ResultPagedList<TenancyResponseDto>.ReSuccess(_mapper.Map<List<TenancyResponseDto>>(list),
      total);
  }

  /// <summary>
  ///   获取租户列表集合
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  [AllowAnonymous]
  public async Task<ResultList<TenancyResponseDto>> GetLists()
  {
    var data = await _tenancyService.GetList();
    if (!data.Success)
      return ResultList<TenancyResponseDto>.ReFailure(data.Message, data.Status);
    return ResultList<TenancyResponseDto>.ReSuccess(_mapper.Map<List<TenancyResponseDto>>(data.Data));
  }

  /// <summary>
  ///   获取租户详情
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<Result<TenancyResponseDto>> Details([FromQuery] long id)
  {
    if (!HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) != 1)
      return Result<TenancyResponseDto>.ReFailure(ResultCodes.RoleNotSuperFailed);
    var data = await _tenancyService.Get(id);
    if (!data.Success)
      return Result<TenancyResponseDto>.ReFailure(data.Message, data.Status);
    return Result<TenancyResponseDto>.ReSuccess(_mapper.Map<TenancyResponseDto>(data.Data));
  }

  /// <summary>
  ///   创建租户
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> Create([FromBody] TenancyCreateRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    if (!HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) != 1)
      return Result.ReFailure(ResultCodes.RoleNotSuperFailed);
    var tenancy = _mapper.Map<Tenancy>(dto);
    tenancy.CreateId = User.UserId();
    return await _tenancyService.Create(tenancy);
  }

  /// <summary>
  ///   修改租户
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> Modify([FromBody] TenancyModifyRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    if (!HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) != 1)
      return Result.ReFailure(ResultCodes.RoleNotSuperFailed);
    var server = _tenancyService;
    var result = await server.Get(long.Parse(dto.Id));
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    result.Data.CreateId = User.UserId();
    return await server.Modify(_mapper.Map(dto, result.Data));
  }

  /// <summary>
  ///   软删除租户
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> Delete([FromBody] ModifyStatusRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    if (!HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) != 1)
      return Result.ReFailure(ResultCodes.RoleNotSuperFailed);
    var server = _tenancyService;
    var result = await server.Get(long.Parse(dto.Id));
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    result.Data.IsDeleted = dto.Status;
    return await server.Modify(result.Data);
  }
}