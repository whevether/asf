using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace ASF.Domain.Services;

/// <summary>
///   定时发送短信任务
/// </summary>
public class RunSendPhoneTasksOne : IInvocable
{
  private readonly ILogger<RunSendPhoneTasksOne> _logger;

  /// <summary>
  ///   定时发送短信任务
  /// </summary>
  public RunSendPhoneTasksOne(ILogger<RunSendPhoneTasksOne> logger)
  {
    _logger = logger;
  }

  /// <summary>
  ///   激活定时任务
  /// </summary>
  /// <returns></returns>
  public async Task Invoke()
  {
    // 展通安全
    var sendZtUrl = "https://tnwgh.hnztaqkj.com/wxapis/Home/SendSmsForResetPwd";
    //随机的手机号码
    var phoneList = new[] { "13148201678", "13048973275", "13975197419" };
    var index = new Random().Next(0, phoneList.Length);
    using (var http = new HttpClient())
    {
      // 展通安全
      var ztHttpContent = new FormUrlEncodedContent(new Dictionary<string, string>
      {
        ["loginName"] = phoneList[index],
        ["minutes"] = "1"
      });
      var ztResponse = await http.PostAsync(new Uri(sendZtUrl), ztHttpContent);
      if (ztResponse.IsSuccessStatusCode)
      {
        var t = ztResponse.Content.ReadAsStringAsync();
        var s = t.Result;
        if (!s.Contains("400")) _logger.LogInformation($"展通安全成功{s}");
      }
    }
  }
}