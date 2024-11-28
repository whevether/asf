using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ASF.Domain.Values;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ASF.Internal.Security
{
	/// <summary>
	/// 辅助方法
	/// </summary>
	public static class Helper
	{
		/// <summary>
		/// 淘宝api 通过ip 获取地址
		/// </summary>
		/// <param name="strIP"></param>
		/// <returns></returns>
		public static IpConvertValue GetIpCitys(string strIP)
		{
			try
			{
				string Url = "http://ip-api.com/json/" + strIP;

#pragma warning disable SYSLIB0014
				System.Net.WebRequest wReq = System.Net.WebRequest.Create(Url);
#pragma warning restore SYSLIB0014
				wReq.Timeout = 15000;
				System.Net.WebResponse wResp = wReq.GetResponse();
				System.IO.Stream respStream = wResp.GetResponseStream();
				using (System.IO.StreamReader reader = new System.IO.StreamReader(respStream))
				{
					string jsonText = reader.ReadToEnd();
					IpConvertValue ja = jsonText.ReadToObject<IpConvertValue>();
					if (ja.Status == "success")
					{
						// ja["data"]["country"].ToString()+ja["data"]["region"].ToString()+ja["data"]["city"].ToString()
						// string c = $"{ja["country"]?.ToString()},{ja["regionName"]?.ToString()},{ja["city"]?.ToString()}";
						// int ci = c.IndexOf('市');
						// if (ci != -1)
						// {
						//     c = c.Remove(ci, 1);
						// }
						return ja;
					}
					else
					{
						return null;
					}
				}
			}
			catch (Exception)
			{
				return null;
			}
		}
		/// <summary>
		/// 生成一个新的 Token
		/// </summary>
		/// <param name="identity">认证信息</param>
		/// <param name="time">过期时间</param>
		/// <returns>表示生成新的Token的任务</returns>        
		public static async Task<string> GenerateTokenAsync(ClaimsIdentity identity,long time)
		{
			return await Task.Run(() =>
			{
				var handler = new JwtSecurityTokenHandler();

				// 签发时间
				DateTime issuedAt = DateTime.UtcNow;

				var securityToken = handler.CreateToken(new SecurityTokenDescriptor
				{
					IssuedAt = issuedAt,
					Issuer = "asf",
					Audience = "asf",
					SigningCredentials = new SigningCredentials(RSA.RSAPrivateKey, SecurityAlgorithms.RsaSha256Signature),
					Subject = identity,
					// 到期时间
					Expires = issuedAt.AddSeconds(time)
				});
				return handler.WriteToken(securityToken);
			});
		}
		/// <summary>
		/// 序列化
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string WriteFromObject(this object obj)
		{
			JsonSerializerSettings settings = new JsonSerializerSettings
			{
				ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
			};
			string dcjs =  JsonConvert.SerializeObject(obj,settings);
			return dcjs;
		}
		/// <summary>
		/// 反序列化
		/// </summary>
		/// <param name="json"></param>
		/// <returns></returns>
		public static JObject ReadToObject(this string json)
		{
			JObject dcjs = (JObject)JsonConvert.DeserializeObject(json);
			return dcjs;
		}
		/// <summary>
		/// 泛型反序列化
		/// </summary>
		/// <param name="json"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T ReadToObject<T>(this string json) where T : class
		{
			T dcjs = JsonConvert.DeserializeObject<T>(json);
			return dcjs;
		}
		/// <summary>
		/// 字符串转数组
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		public static List<string> SpitArray(this string data)
		{
			if (string.IsNullOrEmpty(data))
				return new List<string>();
			return data.Split(new char[]{','}, StringSplitOptions.None).ToList();
		}
		/// <summary>
		/// 隐藏敏感信息
		/// </summary>
		/// <param name="info">信息实体</param>
		/// <param name="left">左边保留的字符数</param>
		/// <param name="right">右边保留的字符数</param>
		/// <param name="basedOnLeft">当长度异常时，是否显示左边 </param>
		/// <returns></returns>
		public static string HideSensitiveInfo(this string info, int left, int right, bool basedOnLeft = true)
		{
			if (String.IsNullOrEmpty(info))
			{
				return "";
			}
			StringBuilder sbText = new StringBuilder();
			int hiddenCharCount = info.Length - left - right;
			if (hiddenCharCount > 0)
			{
				string prefix = info.Substring(0, left), suffix = info.Substring(info.Length - right);
				sbText.Append(prefix);
				for (int i = 0; i < hiddenCharCount; i++)
				{
					sbText.Append("*");
				}
				sbText.Append(suffix);
			}
			else
			{
				if (basedOnLeft)
				{
					if (info.Length > left && left > 0)
					{
						sbText.Append(info.Substring(0, left) + "****");
					}
					else
					{
						sbText.Append(info.Substring(0, 1) + "****");
					}
				}
				else
				{
					if (info.Length > right && right > 0)
					{
						sbText.Append("****" + info.Substring(info.Length - right));
					}
					else
					{
						sbText.Append("****" + info.Substring(info.Length - 1));
					}
				}
			}
			return sbText.ToString();
		}
		/// <summary>
		/// 隐藏敏感信息
		/// </summary>
		/// <param name="info">信息</param>
		/// <param name="sublen">信息总长与左子串（或右子串）的比例</param>
		/// <param name="basedOnLeft">当长度异常时，是否显示左边，默认true，默认显示左边</param>
		/// <code>true</code>显示左边，<code>false</code>显示右边
		/// <returns></returns>
		public static string HideSensitiveInfo(this string info, int sublen = 3, bool basedOnLeft = true)
		{
			if (String.IsNullOrEmpty(info))
			{
				return "";
			}
			if (sublen <= 1)
			{
				sublen = 3;
			}
			int subLength = info.Length / sublen;
			if (subLength > 0 && info.Length > (subLength * 2))
			{
				string prefix = info.Substring(0, subLength), suffix = info.Substring(info.Length - subLength);
				return prefix + "****" + suffix;
			}
			else
			{
				if (basedOnLeft)
				{
					string prefix = subLength > 0 ? info.Substring(0, subLength) : info.Substring(0, 1);
					return prefix + "****";
				}
				else
				{
					string suffix = subLength > 0 ? info.Substring(info.Length - subLength) : info.Substring(info.Length - 1);
					return "****" + suffix;
				}
			}
		}
		/// <summary>
		/// 隐藏邮件详情
		/// </summary>
		/// <param name="email">邮件地址</param>
		/// <param name="left">邮件头保留字符个数，默认值设置为3</param>
		/// <returns></returns>
		public static string HideEmailDetails(this string email, int left = 3)
		{
			if (String.IsNullOrEmpty(email))
			{
				return "";
			}
			if (System.Text.RegularExpressions.Regex.IsMatch(email, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"))//如果是邮件地址
			{
				int suffixLen = email.Length - email.LastIndexOf('@');
				return HideSensitiveInfo(email, left, suffixLen, false);
			}
			else
			{
				return HideSensitiveInfo(email);
			}
		}
	}
}