using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   账户分页请求
/// </summary>
public class AccountListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   用户名
	/// </summary>
	[MaxLength(50, ErrorMessageResourceName = "Val_AccountNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Username { get; set; } = string.Empty;

	/// <summary>
	///   手机号码
	/// </summary>
	[RegularExpression(@"^1[0-9]{10}$", ErrorMessageResourceName = "Val_InvalidPhone", ErrorMessageResourceType = typeof(SharedResource))]
  public string TelPhone { get; set; } = string.Empty;

	/// <summary>
	///   邮箱地址
	/// </summary>
	[RegularExpression(@"^[-\w\+]+(?:\.[-\w]+)*@[-a-z0-9]+(?:\.[a-z0-9]+)*(?:\.[a-z]{2,})$", ErrorMessageResourceName = "Val_InvalidEmail", ErrorMessageResourceType = typeof(SharedResource))]
  public string Email { get; set; } = string.Empty;

	/// <summary>
	///   状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_StatusRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }

	/// <summary>
	///   性别
	/// </summary>
	[Range(0, 2, ErrorMessageResourceName = "Val_GenderRange", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Sex { get; set; }
}