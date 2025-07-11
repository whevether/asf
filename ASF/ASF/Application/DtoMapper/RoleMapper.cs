using System.Linq;
using ASF.Application.DTO.Role;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   角色映射
/// </summary>
public class RoleMapper : Profile
{
  /// <summary>
  ///   角色映射
  /// </summary>
  public RoleMapper()
  {
    // 创建
    CreateMap<RoleCreateRequestDto, Role>();
    // 修改
    CreateMap<RoleModifyRequestDto, Role>();
    //角色响应
    CreateMap<Role, RoleResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.Department, s => s.MapFrom(o => o.Department.Count != 0
        ? o.Department.Select(a => new
        {
          a.Id,
          a.Name,
          a.Enable,
          a.CreateTime
        }).ToList()
        : null))
      .ForMember(f => f.Permission, s => s.MapFrom(o => o.Permission.Count != 0 ? o.Permission.ToList() : null));
  }
}