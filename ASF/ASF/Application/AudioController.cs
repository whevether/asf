using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Application.DTO;
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
///   审计控制器
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class AudioController : ControllerBase
{
  private readonly LoggerService _loggerService;
  private readonly IMapper _mapper;
  private readonly IStringLocalizer<SharedResource> _stringLocalizer;

  /// <summary>
  ///   审计控制器
  /// </summary>
  public AudioController(LoggerService loggerService, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
  {
    _loggerService = loggerService;
    _mapper = mapper;
    _stringLocalizer = stringLocalizer;
  }

  /// <summary>
  ///   获取错误日志列表
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultPagedList<AudioResponseDto>> GetLogList([FromQuery] AudioListRequestDto dto)
  {
    var (list, total) = await _loggerService
      .GetList(dto.PageNo, dto.PageSize, (uint)dto.LogType, dto.AccountName);
    return ResultPagedList<AudioResponseDto>.ReSuccess(_mapper.Map<List<AudioResponseDto>>(list),
      total);
  }

  /// <summary>
  ///   删除错误日志
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> DeleteLog([FromBody] IdArrayRequestDto<string> dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure(_stringLocalizer["onlySuperAdmin"], 3100);
    var server = _loggerService;
    var result = await server.GetList(dto.Ids);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    return await server.Delete(result.Data.ToList());
  }
}