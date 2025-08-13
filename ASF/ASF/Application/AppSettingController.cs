using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Application.DTO;
using ASF.Domain.Services;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application;

/// <summary>
///  app设置
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class AppSettingController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IServiceProvider _serviceProvider;

  /// <summary>
  ///   app设置
  /// </summary>
  public AppSettingController(IServiceProvider serviceProvider, IMapper mapper)
  {
    _serviceProvider = serviceProvider;
    _mapper = mapper;
  }

  /// <summary>
  ///   获取app设置
  /// </summary>
  /// <param name="versionNo"></param>
  /// <param name="id"></param>
  /// <param name="osType"></param>
  /// <returns></returns>
  [AllowAnonymous]
  [HttpGet]
  public async Task<Result<AppSettingResponseDto>> GetAppSetting([FromQuery] string versionNo,
    [FromQuery] int? osType, [FromRoute] long? id)
  {
    var result = await _serviceProvider.GetRequiredService<AppSettingService>().GetAppSetting(versionNo, osType, id);
    if (!result.Success)
      return Result<AppSettingResponseDto>.ReFailure(result.Message, result.Status);
    return Result<AppSettingResponseDto>.ReSuccess(_mapper.Map<AppSettingResponseDto>(result.Data));
  }
}