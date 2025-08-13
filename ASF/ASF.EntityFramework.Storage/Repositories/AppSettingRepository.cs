using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;

namespace ASF.EntityFramework.Repository;
/// <summary>
/// app设置服务
/// </summary>
public class AppSettingRepository: Repositories<AsfAppSetting>, IAppSettingRepository
{
    public AppSettingRepository(RepositoryContext context) : base(context)
    {
    }
}