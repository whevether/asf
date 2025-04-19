using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Application.DTO;
using ASF.Application.DTO.Department;
using ASF.Domain;
using ASF.Domain.Entities;
using ASF.Domain.Services;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application;

/// <summary>
///   部门控制器
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class DepartmentController : ControllerBase
{
  private readonly IMapper _mapper;
  private readonly IServiceProvider _serviceProvider;

  /// <summary>
  ///   部门控制器
  /// </summary>
  public DepartmentController(IServiceProvider serviceProvider, IMapper mapper)
  {
    _serviceProvider = serviceProvider;
    _mapper = mapper;
  }

  /// <summary>
  ///   获取部门分页列表
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultPagedList<DepartmentResponseDto>> GetList(DepartmentListRequestDto dto)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var (list, total) = await _serviceProvider.GetRequiredService<DepartmentService>()
      .GetList(dto.PageNo, dto.PageSize, dto.Name, dto.Status, tenancyId);
    var data = TreeSortMultiLevelFormat(_mapper.Map<List<DepartmentResponseDto>>(list));
    return ResultPagedList<DepartmentResponseDto>.ReSuccess(data.ToList(),
      total);
  }

  /// <summary>
  ///   获取部门列表
  /// </summary>
  /// <returns></returns>
  [HttpGet]
  public async Task<ResultList<DepartmentResponseDto>> GetLists()
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var data = await _serviceProvider.GetRequiredService<DepartmentService>().GetList(tenancyId);
    if (!data.Success)
      return ResultList<DepartmentResponseDto>.ReFailure(data.Message, data.Status);
    var list = TreeSortMultiLevelFormat(_mapper.Map<List<DepartmentResponseDto>>(data.Data)).ToList();
    return ResultList<DepartmentResponseDto>.ReSuccess(list);
  }

  /// <summary>
  ///   无限分级权限菜单
  /// </summary>
  /// <param name="list"></param>
  /// <param name="pid"></param>
  /// <returns></returns>
  private IEnumerable<DepartmentResponseDto> TreeSortMultiLevelFormat(
    IEnumerable<DepartmentResponseDto> list, long pid = 0)
  {
    foreach (var item in list.Where(x => long.Parse(x.Pid) == pid))
      yield return new DepartmentResponseDto
      {
        Key = item.Id,
        Id = item.Id,
        Value = item.Id,
        Label = item.Name,
        Enable = item.Enable,
        TenancyId = item.TenancyId,
        Name = item.Name,
        CreateTime = item.CreateTime,
        Children = TreeSortMultiLevelFormat(list, long.Parse(item.Id))
      };
  }

  /// <summary>
  ///   获取部门详情
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpGet]
  public async Task<Result<DepartmentResponseDto>> Details([FromQuery] long id)
  {
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var data = await _serviceProvider.GetRequiredService<DepartmentService>().Get(id, tenancyId);
    if (!data.Success)
      return Result<DepartmentResponseDto>.ReFailure(data.Message, data.Status);
    return Result<DepartmentResponseDto>.ReSuccess(_mapper.Map<DepartmentResponseDto>(data.Data));
  }

  /// <summary>
  ///   创建部门
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<Result> Create([FromBody] DepartmentCreateRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    // 只有超级管理员才能选择租户创建
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? long.Parse(dto.TenancyId)
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var data = _mapper.Map<Department>(dto);
    data.TenancyId = tenancyId;
    // if (dto.RoleIds.Count != 0)
    // {
    // 	dto.RoleIds.ForEach(f =>
    // 	{
    // 		data.DepartmentRole.Add(new DepartmentRole()
    // 		{
    // 			RoleId = long.Parse(f),
    // 			DepartmentId = data.Id
    // 		});
    // 	});
    // }
    return await _serviceProvider.GetRequiredService<DepartmentService>().Create(data);
  }

  /// <summary>
  ///   修改部门
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> Modify([FromBody] DepartmentModifyRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    var server = _serviceProvider.GetRequiredService<DepartmentService>();
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    if (tenancyId == result.Data.TenancyId && result.Data.Name.Equals(dto.Name))
      return Result.ReFailure(ResultCodes.DepartmentNameExist);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    if (dto.RoleIds != null && dto.RoleIds.Count > 0)
    {
      result.Data.DepartmentRole.Clear();
      dto.RoleIds.ForEach(f =>
      {
        result.Data.DepartmentRole.Add(new DepartmentRole
        {
          RoleId = long.Parse(f),
          DepartmentId = long.Parse(dto.Id)
        });
      });
    }

    return await server.Modify(_mapper.Map(dto, result.Data));
  }

  /// <summary>
  ///   修改角色状态
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> ModifyStatus([FromBody] ModifyStatusRequestDto dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    var server = _serviceProvider.GetRequiredService<DepartmentService>();
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    result.Data.Enable = dto.Status;
    return await server.Modify(result.Data);
  }

  /// <summary>
  ///   分配角色到部门
  /// </summary>
  /// <param name="dto"></param>
  /// <returns></returns>
  [HttpPut]
  public async Task<Result> Assign([FromBody] AssignIdArrayRequestDto<long> dto)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    var server = _serviceProvider.GetRequiredService<DepartmentService>();
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var result = await server.Get(long.Parse(dto.Id), tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    if (dto.Ids == null || dto.Ids.Count == 0)
      return Result.ReFailure(ResultCodes.RoleIdNotExist);
    result.Data.DepartmentRole.Clear();
    foreach (var item in dto.Ids)
      result.Data.DepartmentRole.Add(new DepartmentRole
      {
        RoleId = item,
        DepartmentId = long.Parse(dto.Id)
      });
    return await server.Modify(result.Data);
  }

  /// <summary>
  ///   删除部门
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  [HttpPost("{id}")]
  public async Task<Result> Delete([FromRoute] long id)
  {
    if (!HttpContext.User.IsSuperRole())
      return Result.ReFailure("超级管理员才有权限操作", 3100);
    long? tenancyId = HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1
      ? null
      : Convert.ToInt64(HttpContext.User.TenancyId());
    var server = _serviceProvider.GetRequiredService<DepartmentService>();
    var result = await server.Get(id, tenancyId);
    if (!result.Success)
      return Result.ReFailure(result.Message, result.Status);
    // 除总超级管理员之外其他不允许操作其他租户信息
    if (tenancyId != null && result.Data.TenancyId != tenancyId)
      return Result.ReFailure(ResultCodes.TenancyMatchExist);
    return await server.Delete(result.Data);
  }
}