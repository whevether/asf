using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Application.DTO;
using ASF.Domain;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Results;
using ASF.Internal.Security;
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application
{
	/// <summary>
	/// 权限控制器 只有超级管理员才能有权限控制
	/// </summary>
	[Authorize]
	[Route("[controller]/[action]")]
	public class PermissionController: ControllerBase
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IMapper _mapper;
		/// <summary>
		/// 权限控制器
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <param name="mapper"></param>
		public PermissionController(IServiceProvider serviceProvider, IMapper mapper)
		{
			_serviceProvider = serviceProvider;
			_mapper = mapper;
		}
		/// <summary>
		/// 获取权限分级分页列表
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ResultPagedList<PermissionResponseDto>> GetList(
			[FromQuery] PermissionListRequestDto dto)
		{
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var (data,total) = await _serviceProvider.GetRequiredService<PermissionService>().GetList(dto.PageNo, dto.PageSize, dto.Code,
				dto.Name, dto.Type, dto.IsSystem, dto.Status,tenancyId);
			IEnumerable<PermissionResponseDto> list = _mapper.Map<IEnumerable<PermissionResponseDto>>(data);
			return ResultPagedList<PermissionResponseDto>.ReSuccess(TreeSortMultiLevelFormat(list).ToList(),total);
		}
		/// <summary>
		/// 获取权限列表
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<ResultList<PermissionResponseDto>> GetLists()
		{
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var data = await _serviceProvider.GetRequiredService<PermissionService>().GetList(tenancyId,HttpContext.User.IsSuperRole());
			if(!data.Success)
				return ResultList<PermissionResponseDto>.ReFailure(data.Message,data.Status);
			return ResultList<PermissionResponseDto>.ReSuccess(_mapper.Map<List<PermissionResponseDto>>(data.Data));
		}
		/// <summary>
		/// 获取权限详情
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<Result<PermissionResponseDto>> Details([FromQuery] long id)
		{
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await _serviceProvider.GetRequiredService<PermissionService>().Get(id,tenancyId);
			if (!result.Success)
				return Result<PermissionResponseDto>.ReFailure(result.Message, result.Status);
			return Result<PermissionResponseDto>.ReSuccess(_mapper.Map<PermissionResponseDto>(result.Data));
		}
		/// <summary>
		/// 创建权限
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<Result> Create([FromBody] PermissionCreateRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? long.Parse(dto.TenancyId) : Convert.ToInt64(HttpContext.User.TenancyId());
			Permission permission = _mapper.Map<Permission>(dto);
			permission.TenancyId = tenancyId;
			if(permission.IsSystem != null && (Status)permission.IsSystem == Status.Yes && !HttpContext.User.IsSuperRole())
				return Result.ReFailure(ResultCodes.PermissionSystemNotCreate);
			return await _serviceProvider.GetRequiredService<PermissionService>().Create(permission);
		}
		/// <summary>
		/// 修改权限
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> Modify([FromBody] PermissionModifyRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var server = _serviceProvider.GetRequiredService<PermissionService>();
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			//不是超级管理员不能操作系统级别
			if(result.Data.IsSystem != null && (Status)result.Data.IsSystem == Status.Yes && !HttpContext.User.IsSuperRole())
				return Result.ReFailure(ResultCodes.PermissionSystemNotModify);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			return await server.Modify(_mapper.Map(dto, result.Data));
		}
		/// <summary>
		/// 删除权限
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost("{id}")]
		public async Task<Result> Delete([FromRoute] long id)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var server = _serviceProvider.GetRequiredService<PermissionService>();
			var result = await server.Get(id,tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			//不是超级管理员不能操作系统级别
			if(result.Data.IsSystem != null && (Status)result.Data.IsSystem == Status.Yes && !HttpContext.User.IsSuperRole())
				return Result.ReFailure(ResultCodes.PermissionSystemNotModify);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			return await server.Delete(result.Data);
		}
		/// <summary>
		/// 分配角色权限
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> AssignPermission([FromBody] AssignIdArrayRequestDto<long> dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<RoleService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			if (dto.Ids == null || dto.Ids.Count == 0)
				return Result.ReFailure(ResultCodes.PermissionIdNotExist);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			
			foreach (long value in dto.Ids.ToList())
			{
				if (result.Data.PermissionRole.Count(f => f.PermissionId == value) == 0)
				{
					result.Data.PermissionRole.Add(new PermissionRole()
					{
						PermissionId = value,
						RoleId = long.Parse(dto.Id)
					});
				}	
			}
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 无限分级权限
		/// </summary>
		/// <param name="list"></param>
		/// <param name="pid"></param>
		/// <returns></returns>
		private IEnumerable<PermissionResponseDto> TreeSortMultiLevelFormat(
			IEnumerable<PermissionResponseDto> list, long pid = 0)
		{
			foreach (var item in list.Where(x => long.Parse(x.ParentId) == pid))
			{
				yield return new PermissionResponseDto
				{
					Key = item.Id,
					Id = item.Id,
					Value = item.Id,
					Label = item.Name,
					Name = item.Name,
					TenancyId = item.TenancyId,
					Code = item.Code,
					ParentId = item.ParentId,
					Type = item.Type,
					IsSystem = item.IsSystem,
					Description = item.Description,
					Sort = item.Sort,
					Enable = item.Enable,
					CreateTime = item.CreateTime,
					Children = TreeSortMultiLevelFormat(list, long.Parse(item.Id))
				};
			}
		}
	}
}