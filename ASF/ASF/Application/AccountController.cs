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
using ASF.Internal.Utils;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
namespace ASF.Application
{
	/// <summary>
	/// 账户控制器
	/// </summary>
	[Authorize]
	[Route("[controller]/[action]")]
	public class AccountController: ControllerBase
	{
		private readonly IServiceProvider _serviceProvider;
		private readonly IMapper _mapper;
		/// <summary>
		/// 账户控制器
		/// </summary>
		/// <param name="serviceProvider"></param>
		/// <param name="mapper"></param>
		public AccountController(IServiceProvider serviceProvider, IMapper mapper)
		{
			_serviceProvider = serviceProvider;
			_mapper = mapper;
		}
		/// <summary>
		/// 获取账户登录信息
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public async Task<Result<AccountInfoResponseDto>> AccountInfo()
		{
			
			long uid = HttpContext.User.UserId(); 
			long? tenancyId = HttpContext.User.IsSuperRole() ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var account = await _serviceProvider.GetRequiredService<AccountService>().GetAccountInfo(uid,tenancyId);
			if (!account.Success)
				return Result<AccountInfoResponseDto>.ReFailure(account.Message, account.Status);
			// 权限id 集合
			List<long> permissionIds = new List<long>();
			List<string> role = new List<string>();
			// 遍历部门角色权限
			if (account.Data.Department != null && account.Data.Department.Role.Count != 0)
			{
				foreach (var item in account.Data.Department.Role.ToList())
				{
					role.Add(item.Name);
					permissionIds.AddRange(item.Permission.Select(s => s.Id));
				}
			}
			// 遍历账户角色权限
			if (account.Data.Role.Count != 0)
			{
				foreach (var item in account.Data.Role.ToList())
				{
					// 判断角色重叠不添加
					if(!role.Any(f => f.Equals(item.Name)))
						role.Add(item.Name);
					permissionIds.AddRange(item.Permission.Select(s => s.Id));
				}
			}
			// 权限去重
			permissionIds = permissionIds.Union(permissionIds).ToList();
			var permissionList= await _serviceProvider.GetRequiredService<PermissionService>().GetPermissionListAsync(permissionIds);
			if (!permissionList.Success)
				return Result<AccountInfoResponseDto>.ReFailure(permissionList.Message,permissionList.Status);
			// 权限菜单分级
			var permissionData = _mapper.Map<List<PermissionMenuInfoResponseDto>>(permissionList.Data);
			var breadcrumbItems = permissionData
				.Where(w => !string.IsNullOrEmpty(w.MenuUrl) && !string.IsNullOrEmpty(w.Title))
				.ToDictionary(k => k.MenuUrl, v => v.Title);
			List<PermissionMenuTreeItem<PermissionMenuInfoResponseDto>> permissionMenuTreeItems = TreeSortMultiLevelFormat(permissionData).ToList();
			AccountInfoResponseDto accountInfo = _mapper.Map<AccountInfoResponseDto>(account.Data);
			foreach(var item in permissionList.Data)
			{
				accountInfo.Actions.AddRange(item.Apis.Select(a => new Regex("/").Replace(a.Path, "",1).Replace("api/asf/","").Replace("/",".")));
			}

			accountInfo.BreadcrumbItems = breadcrumbItems;
			accountInfo.RoleName = string.Join(",", role);
			accountInfo.PermissionMenu = permissionMenuTreeItems;
			return Result<AccountInfoResponseDto>.ReSuccess(accountInfo);
		}
		/// <summary>
		/// 无限分级权限菜单
		/// </summary>
		/// <param name="list"></param>
		/// <param name="pid"></param>
		/// <returns></returns>
		private IEnumerable<PermissionMenuTreeItem<PermissionMenuInfoResponseDto>> TreeSortMultiLevelFormat(
			IEnumerable<PermissionMenuInfoResponseDto> list, long pid = 0)
		{
			foreach (var item in list.Where(x => long.Parse(x.ParentId) == pid))
			{
				yield return new PermissionMenuTreeItem<PermissionMenuInfoResponseDto>
				{
					Id = item.Id,
					Name = item.Name,
					Code = item.Code,
					ParentId = item.ParentId,
					Type = item.Type,
					IsSystem = item.IsSystem,
					Description = item.Description,
					Sort = item.Sort,
					Enable = item.Enable,
					CreateTime = item.CreateTime,
					Title = item.Title,
					Subtitle = item.Subtitle,
					Icon = item.Icon,
					MenuHidden = item.MenuHidden,
					MenuUrl = item.MenuUrl,
					MenuRedirect = item.MenuRedirect,
					ExternalLink = item.ExternalLink,
					PermissionDescription = item.PermissionDescription,
					Translate = item.Translate,
					// Actions = item.Actions,
					Children = TreeSortMultiLevelFormat(list,long.Parse( item.Id))
				};
			}
		}
		/// <summary>
		/// 获取账户列表
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<ResultPagedList<AccountResponseDto>> GetList([FromQuery] AccountListRequestDto dto)
		{
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var (list,total)= await _serviceProvider.GetRequiredService<AccountService>().GetList(dto.PageNo,dto.PageSize,dto.Username,dto.TelPhone,dto.Email,dto.Sex,dto.Status,tenancyId);
			return ResultPagedList<AccountResponseDto>.ReSuccess(_mapper.Map<List<AccountResponseDto>>(list),
				total);
		}
		/// <summary>
		/// 获取账户详情
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpGet]
		public async Task<Result<AccountResponseDto>> Details([FromQuery] long id)
		{
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await _serviceProvider.GetRequiredService<AccountService>().GetDetails(id,tenancyId);
			if (!result.Success)
				return Result<AccountResponseDto>.ReFailure(result.Message, result.Status);
			List<object> roles = new List<object>();
			if (result.Data.Department.Role != null && result.Data.Department.Role.Count > 0)
			{
				foreach (var value in result.Data.Department.Role.ToList())
				{
					roles.Add(new
					{
						Key = value.Id,
						value.Id,
						value.Name,
						value.Enable,
						value.Description,
						value.CreateId,
						value.CreateTime,
						value.TenancyId
					});
				}
			}

			if (result.Data.Role != null && result.Data.Role.Count > 0)
			{
				foreach (var value in result.Data.Role.ToList())
				{
					roles.Add(new
					{
						Key = value.Id,
						value.Id,
						value.Name,
						value.Enable,
						value.Description,
						value.CreateId,
						value.CreateTime,
						value.TenancyId
					});
				}
			}
			AccountResponseDto data = _mapper.Map<AccountResponseDto>(result.Data);
			data.Roles = roles;
			return Result<AccountResponseDto>.ReSuccess(data);
		}
		/// <summary>
		/// /创建账户
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<Result> Create([FromBody] AccountCreateRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			// 只有超级管理员才能选择租户创建
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? long.Parse(dto.TenancyId) : Convert.ToInt64(HttpContext.User.TenancyId());
			var data = _mapper.Map<Account>(dto);
			data.TenancyId = tenancyId;
			data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			data.SetPassword(dto.Password);
			// 如果有岗位id 就分配岗位
			if (dto.PostId != null && dto.PostId.Count > 0)
			{
				data.AccountPost.Clear();
				foreach (var pid in dto.PostId)
				{
					data.AccountPost.Add(new AccountPost()
					{
						AccountId =  data.Id,
						PostId =long.Parse(pid)
					});
				}
			}
			return await _serviceProvider.GetRequiredService<AccountService>().Create(data);
		}
		/// <summary>
		/// 修改账户
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> Modify([FromBody] AccountModifyRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.GetDetails(long.Parse(dto.Id));
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			// 判断是否存在相同的角色。如果存在就移除角色相同的部分
			if (result.Data.Role != null && result.Data.Role.Count > 0)
			{
				result.Data.AccountRole.Clear();
				foreach (Role value in result.Data.Role.ToList())
				{
					if (result.Data.Department != null && result.Data.Department.Role.Count > 0 && result.Data.Department.Role.Any(f => f.Id == value.Id))
					{
						result.Data.AccountRole.Remove(new AccountRole()
						{
							AccountId = long.Parse(dto.Id),
							RoleId = value.Id
						});
					}
				}
			}
			// 如果有岗位id 就分配岗位
			if (dto.PostId != null && dto.PostId.Count > 0)
			{
				result.Data.AccountPost.Clear();
				foreach (var pid in dto.PostId)
				{
					result.Data.AccountPost.Add(new AccountPost()
					{
						AccountId =  long.Parse(dto.Id),
						PostId = long.Parse(pid)
					});
				}
			}
			Account data = _mapper.Map(dto, result.Data);
			data.SetPassword(dto.Password);
			return await server.Modify(data);
		}
		/// <summary>
		/// 软删除账户
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpPost("{id}")]
		public async Task<Result> Delete([FromRoute] long id)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(id);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.IsDeleted = (uint) Status.Yes;
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 修改账户状态
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ModifyStatus([FromBody] ModifyStatusRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.Status = dto.Status;
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 重置账户密码
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ResetPassword([FromBody] AccountModifyPasswordRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			var isPassword = result.Data.SetPassword(dto.Password);
			if (!isPassword.Success)
				return isPassword;
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 修改账户邮箱
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ModifyEmail([FromBody] AccountModifyEmailRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			if (!result.Data.Email.Equals(dto.OldEmail))
				return Result.ReFailure(ResultCodes.AccountOldEmailError);
			result.Data.SetEmail(dto.NewEmail);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data,"email");
		}
		/// <summary>
		/// 修改账户名
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ModifyUserName([FromBody] AccountModifyUserNameRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.SetUserName(dto.UserName);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data,"username");
		}
		/// <summary>
		/// 修改账户手机
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ModifyTelPhone([FromBody] AccountModifyTelPhoneRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			if (result.Data.TelPhone.Equals(new PhoneNumber(dto.NewTelPhone,dto.Area).ToString()))
				return Result.ReFailure(ResultCodes.AccountOldTelPhoneError);
			result.Data.SetPhone(dto.NewTelPhone,dto.Area);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data,"telphone");
		}
		/// <summary>
		/// 修改账户头像
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> ModifyAvatar([FromBody] AccountModifyAvatarRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.Get(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.Avatar = dto.Avatar;
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 分配账户角色
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> AssignRole([FromBody] AssignIdArrayRequestDto<string> dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.GetAccountByRole(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			if (dto.Ids.Count == 0)
				return Result.ReFailure(ResultCodes.RoleIdNotExist);
			
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			// 判断是否存在想用的角色。如果存在就忽略分配相同的
			result.Data.AccountRole.Clear();
			foreach (var item in dto.Ids)
			{
				// 判断部门不为空。并且部门角色不包含相同角色添加。 否则直接添加
				if (result.Data.Department != null && result.Data.Department.Role.Count > 0)
				{
					if (result.Data.Department.Role.Any(f => f.Id != long.Parse(item)))
					{
						result.Data.AccountRole.Add(new AccountRole()
						{
							RoleId = long.Parse(item),
							AccountId = result.Data.Id
						});	
					}
				}
				else
				{
					result.Data.AccountRole.Add(new AccountRole()
					{
						RoleId = long.Parse(item),
						AccountId = result.Data.Id
					});	
				}
			}
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 分配账户部门
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> AssignDepartment([FromBody] AccountAssignDepartmentRequestDto dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.GetDetails(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			result.Data.CreateId = Convert.ToInt64(HttpContext.User.UserId());
			// 判断是否存在相同的角色。如果存在就移除角色相同的部分
			if (result.Data.Role != null)
			{
				result.Data.AccountRole.Clear();
				foreach (Role value in result.Data.Role.ToList())
				{
					if (result.Data.Department != null && result.Data.Department.Role.Any(f => f.Id == value.Id))
					{
						result.Data.AccountRole.Remove(new AccountRole()
						{
							AccountId = long.Parse(dto.Id),
							RoleId = value.Id
						});
					}
				}
			}
			// 分配部门id
			result.Data.DepartmentId = long.Parse(dto.DepartmentId);
			return await server.Modify(result.Data);
		}
		/// <summary>
		/// 分配账户岗位
		/// </summary>
		/// <param name="dto"></param>
		/// <returns></returns>
		[HttpPut]
		public async Task<Result> AssignPost([FromBody] AssignIdArrayRequestDto<long> dto)
		{
			if(!HttpContext.User.IsSuperRole())
				return Result.ReFailure("超级管理员才有权限操作",3100);
			var server = _serviceProvider.GetRequiredService<AccountService>();
			long? tenancyId = (HttpContext.User.IsSuperRole() && Convert.ToInt64(HttpContext.User.TenancyId()) == 1) ? null : Convert.ToInt64(HttpContext.User.TenancyId());
			var result = await server.GetAccountByPostAsync(long.Parse(dto.Id),tenancyId);
			if(!result.Success)
				return Result.ReFailure(result.Message,result.Status);
			// 除总超级管理员之外其他不允许操作其他租户信息
			if (tenancyId != null && result.Data.TenancyId != tenancyId)
				return Result.ReFailure(ResultCodes.TenancyMatchExist);
			if (dto.Ids == null || dto.Ids.Count == 0)
				return Result.ReFailure(ResultCodes.PostNotExist);
			result.Data.AccountPost.Clear();
			foreach (var item in dto.Ids)
			{
				result.Data.AccountPost.Add(new AccountPost()
				{
					PostId = item,
					AccountId = long.Parse(dto.Id)
				});
			}
			return await server.Modify(result.Data);
		}
	}
}