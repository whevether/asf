using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改账户密码
/// </summary>
public class AccountModifyPasswordRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   登录密码
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountPasswordRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_AccountPasswordMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_AccountPasswordMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Password { get; set; }
}