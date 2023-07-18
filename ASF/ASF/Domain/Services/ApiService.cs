using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services
{
	/// <summary>
	/// 权限功能
	/// </summary>
	public class ApiService
	{
		private readonly IApiRepository _apiRepository;
		// 雪花算法id
		private readonly IIdGenerator _idGenerator;
		/// <summary>
		/// 权限功能服务
		/// </summary>
		/// <param name="apiRepository"></param>
		/// <param name="idGenerator"></param>
		public ApiService(IApiRepository apiRepository,IIdGenerator idGenerator)
		{
			_apiRepository = apiRepository;
			_idGenerator = idGenerator;
		}
		/// <summary>
		/// 获取权限api
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tenancyId"></param>
		/// <returns></returns>
		public async Task<Result<Api>> Get(long id,long? tenancyId = null)
		{
			Api api = await _apiRepository.GetApiAsync(id,tenancyId);
			if (api == null)
				return Result<Api>.ReFailure(ResultCodes.PermissionApiNotExist);
			return Result<Api>.ReSuccess(api);
		}
		/// <summary>
		/// 获取权限api集合
		/// </summary>
		/// <returns></returns>
		public async Task<ResultList<Api>> GetList(List<string> ids,long? tenancyId)
		{
			if (!ids.Any())
				return ResultList<Api>.ReFailure(ResultCodes.PermissionApiNotExist);
			if (tenancyId != null)
			{
				IEnumerable<Api> list = await _apiRepository.GetEntities(f => (f.IsSystem != null && (Status)f.IsSystem != Status.Yes) && ids.Any(x=> x.Equals(f.Id.ToString())) && f.TenancyId == tenancyId);
				if(list == null)
					return ResultList<Api>.ReFailure(ResultCodes.PermissionApiNotExist);
				return ResultList<Api>.ReSuccess(list.ToList());
			}
			else
			{
				IEnumerable<Api> list = await _apiRepository.GetEntities(f => (f.IsSystem != null && (Status)f.IsSystem != Status.Yes) && ids.Any(x=> x.Equals(f.Id.ToString())));
				if(list == null)
					return ResultList<Api>.ReFailure(ResultCodes.PermissionApiNotExist);
				return ResultList<Api>.ReSuccess(list.ToList());
			}
		}
		/// <summary>
		/// api 分页
		/// </summary>
		/// <param name="pageNo"></param>
		/// <param name="pageSize"></param>
		/// <param name="permissionId"></param>
		/// <param name="type"></param>
		/// <param name="status"></param>
		/// <param name="name"></param>
		/// <param name="httpMethod"></param>
		/// <param name="path"></param>
		/// <param name="tenancyId"></param>
		/// <returns></returns>
		public async Task<(IList<Api> list, int total)> GetList(int pageNo, int pageSize, string permissionId = "",
			uint? type = null, uint? status = null, string name = "", string httpMethod = "",string path = "",long? tenancyId = null)
		{
			return await _apiRepository.GetEntitiesForPaging(pageNo,pageSize,permissionId,type,status,name,httpMethod,path,tenancyId);
			
		}
		/// <summary>
		/// 添加功能api
		/// </summary>
		/// <param name="api"></param>
		/// <returns></returns>
		public async Task<Result> Create(Api api)
		{
			// 判断是否有路径相同
			if (await _apiRepository.GetEntity(f => f.TenancyId == api.TenancyId && f.Path.Equals(api.Path)) != null)
				return Result.ReFailure(ResultCodes.PermissionApiPathExist);
			api.SetId(_idGenerator.GenId());
			var isAdd = await _apiRepository.Add(api);
			if (!isAdd)
			{
				return Result.ReFailure(ResultCodes.PermissionApiCreateError);
			}
			
			return Result.ReSuccess();
		}
		/// <summary>
		/// 修改api
		/// </summary>
		/// <param name="api"></param>
		/// <returns></returns>
		public async Task<Result> Modify(Api api)
		{
			if(await _apiRepository.GetEntity(f => f.Id != api.Id &&f.TenancyId == api.TenancyId&& f.Path.Equals(api.Path)) != null)
				return Result.ReFailure(ResultCodes.PermissionApiPathExist);
			bool isUpdate = await _apiRepository.Update(api);
			if (!isUpdate)
			{
				return Result.ReFailure(ResultCodes.PermissionApiUpdateError);
			}
			return Result.ReSuccess();
		}
		
		/// <summary>
		/// 删除api
		/// </summary>
		/// <param name="api"></param>
		/// <returns></returns>
		public async Task<Result> Delete(Api api)
		{
			bool isdDelete = await _apiRepository.Delete(api);
			if (!isdDelete)
				return Result.ReFailure(ResultCodes.PermissionSysApiDeleteError);
			return Result.ReSuccess();
		}
		/// <summary>
		/// 批量删除授权api
		/// </summary>
		/// <param name="list"></param>
		/// <returns></returns>
		public async Task<Result> BatchDelete(List<Api> list)
		{
			bool isdDelete = await _apiRepository.DeleteRange(list);
			if (!isdDelete)
				return Result.ReFailure(ResultCodes.PermissionSysApiDeleteError);
			return Result.ReSuccess();
		}
	}
}