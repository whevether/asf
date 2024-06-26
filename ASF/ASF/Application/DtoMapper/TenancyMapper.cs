using System.Linq;
using ASF.Application.DTO.Tenancy;
using ASF.Domain.Entities;
using AutoMapper;

namespace ASF.Application.DtoMapper
{
	/// <summary>
	/// 租户映射
	/// </summary>
	public class TenancyMapper: Profile
	{
		/// <summary>
		/// 租户映射
		/// </summary>
		public TenancyMapper()
		{
			//创建
			this.CreateMap<TenancyCreateRequestDto, Tenancy>();
			//修改
			this.CreateMap<TenancyModifyRequestDto, Tenancy>();
			//响应
			this.CreateMap<Tenancy, TenancyResponseDto>()
				.ForMember(f=>f.Key,s=>s.MapFrom(o=>o.Id))
				.ForMember(f => f.Accounts, s => s.MapFrom(o => o.Accounts.Select(a => new
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
				})));
		}
	}
}