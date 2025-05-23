using ASF.Application.DTO.Country;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   国家映射
/// </summary>
public class CountryMapper : Profile
{
  /// <summary>
  ///   国家映射
  /// </summary>
  public CountryMapper()
  {
    // 创建
    CreateMap<CountryCreateRequestDto, Country>();
    // 修改
    CreateMap<CountryModifyRequestDto, Country>();
    // 国家响应
    CreateMap<Country, CountryResponseDto>();
  }
}