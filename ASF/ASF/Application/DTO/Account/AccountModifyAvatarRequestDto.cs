using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改账户头像
/// </summary>
public class AccountModifyAvatarRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	public string Id { get; set; }

	/// <summary>
	///   头像
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_AvatarMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Avatar { get; set; }
}