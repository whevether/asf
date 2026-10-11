using System;

namespace ASF.Domain.Values;

/// <summary>
///   授权token
/// </summary>
public class AccessToken
{
	/// <summary>
	///   授权token
	/// </summary>
	public string Token { get; set; }

	/// <summary>
	///   token头标识
	/// </summary>
	public string TokenType { get; set; } = "Bearer";

	/// <summary>
	///   刷新token
	/// </summary>
	public string RefreshToken { get; set; }

	/// <summary>
	///   过期时间
	/// </summary>
	public DateTime Expired { get; set; }

	/// <summary>
	///   im token
	/// </summary>
	public string ImToken { get; set; }

	/// <summary>
	///   ASF 会员 Id（= go-chat users.id）
	/// </summary>
	public int UserId { get; set; }

	/// <summary>
	///   email验证token
	/// </summary>
	public string EmailToken { get; set; }

	/// <summary>
	///   是否为绑定邮箱
	/// </summary>
	public bool IsBindEmail { get; set; } = false;

	/// <summary>
	///   未注册社交登录时的账号（google_{sub} / apple_{sub}）
	/// </summary>
	public string Account { get; set; }

	/// <summary>
	///   未注册社交登录时的邮箱；没有真实邮箱则为空
	/// </summary>
	public string Email { get; set; }
}
