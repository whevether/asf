using System.Linq;
using ASF.Application.DTO.Tenancy;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   租户映射
/// </summary>
public class TenancyMapper : Profile
{
  /// <summary>
  ///   租户映射
  /// </summary>
  public TenancyMapper()
  {
    //创建
    CreateMap<TenancyCreateRequestDto, Tenancy>();
    //修改
    CreateMap<TenancyModifyRequestDto, Tenancy>();
    //响应
    CreateMap<Tenancy, TenancyResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.Accounts, s => s.MapFrom(o => o.Accounts.Select(a => new
      {
        Id = a.Id.ToString(),
        a.Name,
        a.Username,
        a.TelPhone,
        a.Email,
        a.Avatar,
        a.Status,
        a.IsDeleted,
        a.LoginIp,
        a.LoginTime,
        a.LoginLocation,
        CreateId = a.CreateId.ToString(),
        a.Sex,
        a.CreateTime
      })));
  }
}