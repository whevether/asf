using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   账户
/// </summary>
public class AccountModifyRequestDto : AccountCreateRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }
}