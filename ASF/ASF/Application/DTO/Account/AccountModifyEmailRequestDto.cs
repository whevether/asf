using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改账户邮箱
/// </summary>
public class AccountModifyEmailRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   旧邮箱地址
	/// </summary>
	[RegularExpression(@"^[-\w\+]+(?:\.[-\w]+)*@[-a-z0-9]+(?:\.[a-z0-9]+)*(?:\.[a-z]{2,})$", ErrorMessageResourceName = "Val_InvalidEmail", ErrorMessageResourceType = typeof(SharedResource))]
  public string OldEmail { get; set; }

	/// <summary>
	///   新邮箱地址
	/// </summary>
	[RegularExpression(@"^[-\w\+]+(?:\.[-\w]+)*@[-a-z0-9]+(?:\.[a-z0-9]+)*(?:\.[a-z]{2,})$", ErrorMessageResourceName = "Val_InvalidEmail", ErrorMessageResourceType = typeof(SharedResource))]
  public string NewEmail { get; set; }
}