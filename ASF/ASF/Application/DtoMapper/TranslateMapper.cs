using ASF.Application.DTO.Translate;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   多语言映射
/// </summary>
public class TranslateMapper : Profile
{
  /// <summary>
  ///   多语言映射
  /// </summary>
  public TranslateMapper()
  {
    // 创建
    CreateMap<TranslateCreateRequestDto, Translate>();
    // 修改
    CreateMap<TranslateModifyRequestDto, Translate>();
    // 多语言响应
    CreateMap<Translate, TranslateResponseDto>();
  }
}