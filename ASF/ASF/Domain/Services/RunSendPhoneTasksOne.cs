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
      string[] phoneList = new string[]{"13623996354","13338130380","18638065564","15138191072","13838193711","15139811102","13838186236","15938313868","15138191072","15138390130","13838186236","15238198777","15238238231","15139811102","15638352015","15138191072","13638320892","15139811102","13838186236","18338139606","13623996354","18638319669","13838130691","15138387155","15138390130","15139811102","18738392262","18638065564","13838186236","18738392262","15139811102","15138191072","18338139606","18338139606","18638319669","13623996354","15638352015","15238198777","13623996354","18738392262","18338139606","15139811102","13338130380","13338130380","13338130380","13623996354","15238198777","13338130380","18638065564","18838239680","15238238231","18338139606","15238238231","15638352015","18638065564","13838193711","18838239680","15138387155","15638352015","15638352015","18638065564","18638065564","18338356216","13638320892","18738392262","13338130380","13338130380","13938314694","13338130380","18638065564","13838186236","15238198777","13938314694","15638352015","13623996354","13838193711","15138387155","18338139606","15938312688","18338139606","18638319669","15938312688","18738392262","15238238231","18638065564","15238238231","15938313868","18838239680","15138191072","15938312688","18338356216","18638319669","15238238231","15638352015","18338139606","18638065564","13338130380","13838130691","13623996354","18338139606","13838186236","15138191072","13838193711","15238198777","15238238231","18838239680","15938312688","15938313868","13938314694","18638319669","13638320892","15638352015","18338356216","15139811102","15138387155","15138390130","18738392262"};
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