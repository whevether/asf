﻿using System.Collections.Generic;
using ASF.Application.DTO.AsfDictionary;
using ASF.Domain.Entities;
using ASF.Internal.Security;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   字典映射
/// </summary>
public class AsfDictionaryMapper : Profile
{
    /// <summary>
    ///   字典映射
    /// </summary>
    public AsfDictionaryMapper()
  {
    CreateMap<AsfDictionaryCreateRequestDto, AsfDictionary>()
      .ForMember(f => f.Options,
        s => s.MapFrom(o => o.Options.WriteFromObject()));
    CreateMap<AsfDictionaryModifyRequestDto, AsfDictionary>()
      .ForMember(f => f.Options,
        s => s.MapFrom(o => o.Options.WriteFromObject()));
    CreateMap<AsfDictionary, AsfDictionaryResponseDto>()
      .ForMember(f => f.Options,
        s => s.MapFrom(o => o.Options.ReadToObject<Dictionary<string, string>>()));
  }
}