using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Application.DTO.AsfDictionary;
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
///   字典控制器
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class DictionaryController : ControllerBase
{
  private readonly DictionaryService _dictionaryService;
  private readonly IMapper _mapper;
  private readonly IStringLocalizer<SharedResource> _stringLocalizer;

  /// <summary>
  ///   字典控制器
  /// </summary>
  public DictionaryController(DictionaryService dictionaryService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
  {
    _dictionaryService = dictionaryService;
    _mapper = mapper;
    _stringLocalizer = stringLocalizer;
  }

  /// <summary>
  ///   获取字典分页
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultPagedList<AsfDictionaryResponseDto>> GetList(
    [FromQuery] AsfDictionaryListRequestDto dto)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var (list, total) = await _dictionaryService
      .GetList(dto.PageNo, dto.PageSize, dto.Key, tenancyId);
    return ResultPagedList<AsfDictionaryResponseDto>.ReSuccess(_mapper.Map<List<AsfDictionaryResponseDto>>(list),
      total);
  }

  /// <summary>
  ///   获取字典列表
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultList<AsfDictionaryResponseDto>> GetLists()
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var data = await _dictionaryService.GetList(tenancyId);
    if (!data.Success)
      return ResultList<AsfDictionaryResponseDto>.ReFailure(data.Message, data.Status);
    return ResultList<AsfDictionaryResponseDto>.ReSuccess(_mapper.Map<List<AsfDictionaryResponseDto>>(data.Data));
  }

  /// <summary>
  ///   获取字典详情
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<Result<AsfDictionaryResponseDto>> Details([FromQuery] long id)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var data = await _dictionaryService.Get(id, tenancyId);
    if (!data.Success)
      return Result<AsfDictionaryResponseDto>.ReFailure(data.Message, data.Status);
    return Result<AsfDictionaryResponseDto>.ReSuccess(_mapper.Map<AsfDictionaryResponseDto>(data.Data));
  }

  /// <summary>
  ///   创建字典
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> Create([FromBody] AsfDictionaryCreateRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    // 只有超级管理员才能选择租户创建
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? long.Parse(dto.TenancyId)
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var asfDictionary = _mapper.Map<AsfDictionary>(dto);
    asfDictionary.TenancyId = tenancyId;
    return await _dictionaryService.Create(asfDictionary);
  }

  /// <summary>
  ///   修改字典
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> Modify([FromBody] AsfDictionaryModifyRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    var server = _dictionaryService;
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    return await _dictionaryService.Modify(_mapper.Map(dto, result.Data));
  }

  /// <summary>
  ///   删除字典
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpPost("{id}")]
  public async Task<Result> Delete([FromRoute] long id)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    var server = _dictionaryService;
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await server.Get(id, tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    return await server.Delete(result.Data);
  }
}