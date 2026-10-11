using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ASF.Domain.Entities;
using ASF.Domain.Values;
using ASF.Infrastructure.Repositories;
using ASF.Internal.Results;
using ASF.Internal.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ASF.Domain.Services;

/// <summary>
///   账号权限认证服务
/// </summary>
public class AccountAuthorizationService
{
  private readonly IAccountsRepository _accountsRepository;
  private readonly IApiRepository _apiRepository;
  private readonly IHttpContextAccessor _httpContextAccessor;
  private readonly ILogger _logger;
  private readonly IMemoryCache _memoryCache;

  /// <summary>
  ///   账户认证服务
  /// </summary>
  public AccountAuthorizationService(
    IHttpContextAccessor httpContextAccessor,
    IApiRepository apiRepository,
    IAccountsRepository accountsRepository,
    IMemoryCache memoryCache,
    ILogger<AccountAuthorizationService> logger)
  {
    _httpContextAccessor = httpContextAccessor;
    _apiRepository = apiRepository;
    _accountsRepository = accountsRepository;
    _memoryCache = memoryCache;
    _logger = logger;
  }

  /// <summary>
  ///   认证
  /// </summary>
  public async Task<Result<Api>> Authentication()
  {
    var context = _httpContextAccessor.HttpContext;
    var request = context.Request;
    var requestPath = (request.PathBase + request.Path).ToString().ToLower();

    var api = await MatchApiPermission(requestPath.Trim());
    if (api == null)
    {
      _logger.LogWarning($"没有这个权限 {requestPath}");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    _logger.LogDebug($"[{request.Method}]{requestPath} 匹配权限id {api.Id}");
    if (!api.HttpMethods.Contains(request.Method.ToLower()))
    {
      _logger.LogWarning($"请求方法不匹配 : [{request.Method}]{requestPath}");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    if (api.Status == 0)
    {
      _logger.LogWarning($"{api.Id} api被禁用");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    if ((PermissionType)api.Type == PermissionType.OpenApi)
    {
      _logger.LogDebug($"{api.Id} 公开api授权成功");
      return Result<Api>.ReSuccess(api);
    }

    var uid = context.User.UserId();
    var account = await _accountsRepository.GetAccountAndRoleAndPermissionAsync(uid);
    if (account == null)
    {
      _logger.LogWarning($"{uid} 账户不存在");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    if (account.Role.Count == 0 && account.Department != null && account.Department.Role.Count == 0)
    {
      _logger.LogDebug("账户不包含角色");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    if (account.Department != null && account.Department.Role.Count != 0 && account.Department.Role.Any(f =>
          (f.Enable != null && (EnabledType)f.Enable == EnabledType.Disabled) || f.Permission.Count(x =>
            x.Enable != null && (EnabledType)x.Enable == EnabledType.Enable && x.Id == api.PermissionId) == 0)
        &&
        account.Role.Count != 0 && account.Role.Any(f =>
          (f.Enable != null && (EnabledType)f.Enable == EnabledType.Disabled) || f.Permission.Count(x =>
            x.Enable != null && (EnabledType)x.Enable == EnabledType.Enable && x.Id == api.PermissionId) == 0))
    {
      _logger.LogWarning($"角色 {string.Join(",", account.Department.Role.Select(s => s.Name))} 被禁用");
      return Result<Api>.ReFailure(ResultCodes.NotAcceptable);
    }

    _logger.LogDebug("认证成功");
    return Result<Api>.ReSuccess(api);
  }

  private async Task<Api> MatchApiPermission(string requestPath)
  {
    var apis = await _memoryCache.GetOrCreateAsync("ASF_API_PERMISSION_LIST", async entry =>
    {
      entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
      var list = await _apiRepository.GetEntities(f => f.Id != 0);
      return list?.ToArray() ?? Array.Empty<Api>();
    });

    if (apis == null || apis.Length == 0)
      return null;
    return apis.FirstOrDefault(f => Regex.IsMatch(requestPath, $"^{f.Path.ToLower()}$"));
  }
}
