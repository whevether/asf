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
	[Required(ErrorMessage = "账户id不能为空")]
  public string Id { get; set; }
}