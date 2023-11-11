using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Application.DTO.Country;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application
{
	/// <summary>
	/// 国家控制器
	/// </summary>
	[Authorize]
	[Route("[controller]/[action]")]
	public class CountryController: ControllerBase
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IMapper _mapper;
		/// <summary>
		/// 国家控制器
		/// </summary>
		public CountryController(IServiceProvider serviceProvider, IMapper mapper)
		{
			_serviceProvider = serviceProvider;
			_mapper = mapper;
		}
		/// <summary>
		/// 获取国家分页
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ResultPagedList<CountryResponseDto>> GetList([FromQuery] CountryListRequestDto dto)
		{
			var (list,total) = await _serviceProvider.GetRequiredService<CountryService>().GetList(dto.PageNo,dto.PageSize,dto.Name);
			return ResultPagedList<CountryResponseDto>.ReSuccess(_mapper.Map<List<CountryResponseDto>>(list),
				total);
		}
		/// <summary>
		/// 获取国家列表
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		[AllowAnonymous]
		public async Task<ResultList<CountryResponseDto>> GetLists()
		{
			var data = await _serviceProvider.GetRequiredService<CountryService>().GetList();
			if(!data.Success)
				return ResultList<CountryResponseDto>.ReFailure(data.Message,data.Status);
			return ResultList<CountryResponseDto>.ReSuccess(_mapper.Map<List<CountryResponseDto>>(data.Data));
		}
		
		/// <summary>
		/// 获取国家详情
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<Result<CountryResponseDto>> Details([FromQuery] long id)
		{
			var data = await _serviceProvider.GetRequiredService<CountryService>().Get(id);
			if (!data.Success)
				return Result<CountryResponseDto>.ReFailure(data.Message, data.Status);
			return Result<CountryResponseDto>.ReSuccess(_mapper.Map<CountryResponseDto>(data.Data));
		}

		/// <summary>
		/// 创建国家
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<Result> Create([FromBody] CountryCreateRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			Country country = _mapper.Map<Country>(dto);
			return await _serviceProvider.GetRequiredService<CountryService>().Create(country);
		}
		/// <summary>
		/// 修改国家
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> Modify([FromBody] CountryModifyRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<CountryService>();
			var result = await server.Get(long.Parse(dto.Id));
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			return await _serviceProvider.GetRequiredService<CountryService>().Modify(_mapper.Map(dto,result.Data));
		}
		/// <summary>
		/// 删除国家
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost("{id}")]
		public async Task<Result> Delete([FromRoute] long id)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<CountryService>();
			var result = await server.Get(id);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			return await server.Delete(result.Data);
		}
	}
}