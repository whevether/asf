using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改账户名
/// </summary>
public class AccountModifyUserNameRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   账户名
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string UserName { get; set; }
}