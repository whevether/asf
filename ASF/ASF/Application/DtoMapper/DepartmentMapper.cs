using System.Linq;
using ASF.Application.DTO.Department;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper;

/// <summary>
///   部门映射
/// </summary>
public class DepartmentMapper : Profile
{
	/// <summary>
	///   部门映射
	/// </summary>
	public DepartmentMapper()
  {
    //创建
    CreateMap<DepartmentCreateRequestDto, Department>();
    //修改
    CreateMap<DepartmentModifyRequestDto, Department>();
    //响应
    CreateMap<Department, DepartmentResponseDto>()
      .ForMember(f => f.Key, s => s.MapFrom(o => o.Id))
      .ForMember(f => f.Roles, s => s.MapFrom(o => o.Role.Count != 0
        ? o.Role.Select(a => new
        {
          Id = a.Id.ToString(),
          a.Name,
          a.Enable,
          CreateId = a.CreateId.ToString(),
          a.Description,
          a.CreateTime
        })
        : null))
      .ForMember(f => f.Accounts, s => s.MapFrom(o => o.Accounts.Count != 0
        ? o.Accounts.Select(a => new
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
        })
        : null));
  }
}