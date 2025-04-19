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
	[Required(ErrorMessage = "账户id不能为空")]
  public string Id { get; set; }

	/// <summary>
	///   账户名
	/// </summary>
	[Required(ErrorMessage = "账户名称不能为空")]
  public string UserName { get; set; }
}