using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Entities;

namespace ASF.Infrastructure.Repositories
{
  /// <summary>
  /// api 仓储
  /// </summary>
  public interface IApiRepository: IRepositories<Api>
  {
    /// <summary>
    /// 获取权限功能详情
    /// </summary>
    /// <param name="id"></param>
    /// <param name="tenancyId"></param>
    /// <returns></returns>
    Task<Api> GetApiAsync(long id,long? tenancyId = null);
    /// <summary>
    /// 
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
    Task<(IList<Api> list, int total)> GetEntitiesForPaging(int pageNo, int pageSize, string permissionId = "",
      uint? type = null, uint? status = null, string name = "", string httpMethod = "", string path = "",
      long? tenancyId = null);
  }
}