using ASF.Application.DTO;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;
/// <summary>
/// 
/// </summary>
public class AppSettingMapper: Profile
{
    /// <summary>
    /// 
    /// </summary>
    public AppSettingMapper()
    {
        this.CreateMap<AsfAppSetting, AppSettingResponseDto>()
            .ForMember(f => f.Key, s => s.MapFrom(o => o.Id));
    }
}