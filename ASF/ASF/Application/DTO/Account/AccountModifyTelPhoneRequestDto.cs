using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改账户手机号码
/// </summary>
public class AccountModifyTelPhoneRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   手机区号 默认 86
	/// </summary>
	public int Area { get; set; } = 86;

	/// <summary>
	///   新手机号码
	/// </summary>
	[RegularExpression(@"^1[0-9]{10}$", ErrorMessageResourceName = "Val_InvalidPhone", ErrorMessageResourceType = typeof(SharedResource))]
  public string NewTelPhone { get; set; }
}