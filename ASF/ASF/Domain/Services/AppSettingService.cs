using System;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal.Results;
using ASF.Internal.Security;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace ASF.Domain.Services;

/// <summary>
///   app设置服务
/// </summary>
public class AppSettingService
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    ///   app设置服务
    /// </summary>
    /// <param name="serviceProvider"></param>
    public AppSettingService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    ///   获取App设置
    /// </summary>
    /// <param name="versionNo"></param>
    /// <param name="id"></param>
    /// <param name="osType"></param>
    /// <returns></returns>
    public async Task<Result<AsfAppSetting>> GetAppSetting(string versionNo, int? osType, long? id)
    {
        var service = _serviceProvider.GetRequiredService<IAppSettingRepository>();
        if (!string.IsNullOrEmpty(versionNo) && osType != null)
        {
            var result = await service.GetEntities(f => f.OsType != osType && f.UpdateStatus == 1);
            if (result != null)
            {
                var data = result.FirstOrDefault(f => f.VersionNo.ParseVersion() > versionNo.ParseVersion());
                return Result<AsfAppSetting>.ReSuccess(data);
            }

            return Result<AsfAppSetting>.ReSuccess(null);
        }

        if (id == null)
            return Result<AsfAppSetting>.ReFailure("app id不能为空", 1101);
        var res = await service.GetEntity(f => f.Id == id);
        if (res == null)
            return Result<AsfAppSetting>.ReFailure("没有找到数据", 1008);
        return Result<AsfAppSetting>.ReSuccess(res);
    }
}