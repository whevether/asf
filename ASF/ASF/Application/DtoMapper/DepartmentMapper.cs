using System.Linq;
using ASF.Application.DTO.Department;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper
{
	/// <summary>
	/// 部门映射
	/// </summary>
	public class DepartmentMapper: Profile
	{
		/// <summary>
		/// 部门映射
		/// </summary>
		public DepartmentMapper()
		{
			//创建
			this.CreateMap<DepartmentCreateRequestDto, Department>();
			//修改
			this.CreateMap<DepartmentModifyRequestDto, Department>();
			//响应
			this.CreateMap<Department,DepartmentResponseDto>()
				.ForMember(f=>f.Key,s=>s.MapFrom(o=>o.Id))
				.ForMember(f => f.Roles, s=> s.MapFrom(o => o.Role.Count != 0 ? o.Role.Select(a=> new
				{
					Id = a.Id.ToString(),
					Name = a.Name,
					Enable = a.Enable,
					CreateId = a.CreateId.ToString(),
					Description = a.Description,
					CreateTime = a.CreateTime
				}) : null))
				.ForMember(f => f.Accounts, s=> s.MapFrom(o => o.Accounts.Count != 0 ? o.Accounts.Select(a=> new
				{
					Id = a.Id.ToString(),
					Name = a.Name,
					Username = a.Username,
					TelPhone = a.TelPhone,
					Email = a.Email,
					Avatar = a.Avatar,
					Status = a.Status,
					IsDeleted = a.IsDeleted,
					LoginIp = a.LoginIp,
					LoginTime = a.LoginTime,
					LoginLocation = a.LoginLocation,
					CreateId = a.CreateId.ToString(),
					Sex = a.Sex,
					CreateTime = a.CreateTime
				}) : null));
		}
	}
}