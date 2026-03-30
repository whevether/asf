using System.Linq;
using ASF.Application.DTO;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   账户映射
/// </summary>
public class AccountMapper : Profile
{
    /// <summary>
    ///   账户映射
    /// </summary>
    public AccountMapper()
  {
    // 账户权限菜单等响应
    CreateMap<Account, AccountInfoResponseDto>();
    //创建账户
    CreateMap<AccountCreateRequestDto, Account>()
      .ForMember(f => f.TelPhone, s => s.MapFrom(o => new PhoneNumber(o.TelPhone, o.Area)));
    // 修改账户
    CreateMap<AccountModifyRequestDto, Account>()
      .ForMember(f => f.TelPhone, s => s.MapFrom(o => new PhoneNumber(o.TelPhone, o.Area)));
    // 账户响应数据
    CreateMap<Account, AccountResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.Roles, s => s.MapFrom(o => o.Role.Count > 0
        ? o.Role.Select(ss => new
        {
          Key = ss.Id.ToString(),
          Id = ss.Id.ToString(),
          TenancyId = ss.TenancyId.ToString(),
          ss.Name,
          ss.Description,
          ss.Enable,
          CreateId = ss.CreateId.ToString(),
          ss.CreateTime
        })
        : null))
      .ForMember(f => f.Department, s => s.MapFrom(o => o.Department != null
        ? new
        {
          Id = o.Department.Id.ToString(),
          Pid = o.Department.Pid.ToString(),
          TenancyId = o.Department.TenancyId.ToString(),
          o.Department.Name,
          o.Department.Enable,
          o.Department.Sort,
          o.Department.CreateTime
        }
        : null))
      .ForMember(f => f.Posts, s => s.MapFrom(o => o.Post.Count > 0
        ? o.Post.Select(a => new
        {
          Key = a.Id.ToString(),
          Id = a.Id.ToString(),
          TenancyId = a.TenancyId.ToString(),
          a.Name,
          a.Enable,
          a.Sort,
          a.CreateTime,
          CreateId = a.CreateId.ToString(),
          a.Description
        })
        : null))
      .ForMember(f => f.Tenancys, s => s.MapFrom(o => o.Tenancys != null
        ? new
        {
          Id = o.Tenancys.Id.ToString(),
          o.Tenancys.Name,
          o.Tenancys.Status,
          o.Tenancys.Sort,
          o.Tenancys.CreateTime,
          CreateId = o.Tenancys.CreateId.ToString(),
          o.Tenancys.IsDeleted
        }
        : null));
  }
}