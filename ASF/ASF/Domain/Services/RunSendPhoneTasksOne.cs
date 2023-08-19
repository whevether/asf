using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Coravel.Invocable;
using Microsoft.Extensions.Logging;

namespace ASF.Domain.Services
{
  /// <summary>
  /// 定时发送短信任务
  /// </summary>
  public class RunSendPhoneTasksOne : IInvocable
  {
    private readonly ILogger<RunSendPhoneTasksOne> _logger;
    /// <summary>
    /// 定时发送短信任务
    /// </summary>
    public RunSendPhoneTasksOne(ILogger<RunSendPhoneTasksOne> logger)
    {
      _logger = logger;
    }
    /// <summary>
    /// 激活定时任务
    /// </summary>
    /// <returns></returns>
    public async Task Invoke()
    {
      // 展通安全
      string sendZtUrl = "https://tnwgh.hnztaqkj.com/Home/SendSmsForResetPwd";
      //随机的手机号码
      string[] phoneList = new string[]{"18638065564","13338130380","13838130691","13623996354","18338139606","13838186236","15138191072","13838193711","15238198777","15238238231","18838239680","15938312688","15938313868","13938314694","18638319669","13638320892","15638352015","18338356216","15139811102","15138387155","15138390130","18738392262"};
      var index = new Random().Next(0, phoneList.Length);
      using (var http = new HttpClient())
      {
        // 展通安全
        FormUrlEncodedContent ztHttpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
        {
          ["loginName"] = phoneList[index],
          ["minutes"] = "1"
        });
        HttpResponseMessage ztResponse = await http.PostAsync(new Uri(sendZtUrl), ztHttpContent);
        if (ztResponse.IsSuccessStatusCode)
        {
          Task<string> t = ztResponse.Content.ReadAsStringAsync();
          string s = t.Result;
          if (!s.Contains("400"))
          {
            _logger.LogInformation($"展通安全成功{s}");
          }
        }
      }
    }
  }
}