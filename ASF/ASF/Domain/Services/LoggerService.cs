using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Infrastructure.Repositories;
using ASF.Internal;
using ASF.Internal.Results;

namespace ASF.Domain.Services;

/// <summary>
///   日志服务
/// </summary>
public class LoggerService
{
  private readonly IIdGenerator _idGenerator;
  private readonly ILoggingsRepository _loggingsRepository;

  /// <summary>
  ///   日志服务
  /// </summary>
  /// <param name="loggingsRepository"></param>
  /// <param name="idGenerator"></param>
  public LoggerService(ILoggingsRepository loggingsRepository, IIdGenerator idGenerator)
  {
    _loggingsRepository = loggingsRepository;
    _idGenerator = idGenerator;
  }

  /// <summary>
  ///   添加日志
  /// </summary>
  /// <param name="logInfo"></param>
  /// <returns></returns>
  public async Task Create(LogInfo logInfo)
  {
    logInfo.SetId(_idGenerator.GenId());
    await _loggingsRepository.Add(logInfo);

    await Task.CompletedTask;
  }

  /// <summary>
  ///   获取日志分页列表
  /// </summary>
  /// <param name="pageNo"></param>
  /// <param name="pageSize"></param>
  /// <param name="type"></param>
  /// <param name="accountName"></param>
  /// <returns></returns>
  public async Task<(IList<LogInfo> list, int total)> GetList(int pageNo, int pageSize, uint? type = null,
    string accountName = "")
  {
    if (type != null && !string.IsNullOrEmpty(accountName))
    {
      var (list, total) = await _loggingsRepository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Type == type && f.AccountName.Equals(accountName));
      return (list, total);
    }

    if (type != null)
    {
      var (list, total) = await _loggingsRepository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.Type == type);
      return (list, total);
    }

    if (!string.IsNullOrEmpty(accountName))
    {
      var (list, total) = await _loggingsRepository.GetEntitiesForPaging(pageNo, pageSize,
        f => f.AccountName.Equals(accountName));
      return (list, total);
    }

    var (data, totalCount) = await _loggingsRepository.GetEntitiesForPaging(pageNo, pageSize,
      f => f.Id != 0);
    return (data, totalCount);
  }

  /// <summary>
  ///   获取审计日志
  /// </summary>
  /// <param name="id"></param>
  /// <returns></returns>
  public async Task<Result<LogInfo>> Get(long id)
  {
    var logInfo = await _loggingsRepository.GetEntity(f => f.Id == id);
    if (logInfo == null)
      return Result<LogInfo>.ReFailure(ResultCodes.LoggingNotExist);
    return Result<LogInfo>.ReSuccess(logInfo);
  }

  /// <summary>
  ///   获取审计日志
  /// </summary>
  /// <param name="ids"></param>
  /// <returns></returns>
  public async Task<ResultList<LogInfo>> GetList(List<string> ids)
  {
    if (!ids.Any())
      return ResultList<LogInfo>.ReFailure("没有日志数据", 3500);

    var list = await _loggingsRepository.GetEntities(f => ids.Any(x => x.Equals(f.Id.ToString())));
    if (list == null)
      return ResultList<LogInfo>.ReFailure("没有日志数据", 3500);
    return ResultList<LogInfo>.ReSuccess(list.ToList());
  }

  /// <summary>
  ///   删除日志
  /// </summary>
  /// <param name="logInfo"></param>
  /// <returns></returns>
  public async Task<Result> Delete(List<LogInfo> logInfo)
  {
    // 判断如果日志时间不大于三个月不能删除
    if (logInfo.Any(a => a.AddTime.AddDays(90) < DateTime.UtcNow))
      return Result.ReFailure(ResultCodes.LogginDeletedCannoBeWithinThreeMonths);
    var isDelete = await _loggingsRepository.DeleteRange(logInfo);
    if (!isDelete) return Result.ReFailure(ResultCodes.LogginDeletedError);
    return Result.ReSuccess();
  }
}