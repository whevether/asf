using ASF.Application.DTO;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   审计日志映射
/// </summary>
public class AudioMapper : Profile
{
	/// <summary>
	///   审计日志映射
	/// </summary>
	public AudioMapper()
  {
    CreateMap<LogInfo, AudioResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id));
  }
}