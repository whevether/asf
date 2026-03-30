using ASF.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   创建账户
/// </summary>
public class AccountCreateRequestDto
{
	/// <summary>
	///   部门id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_DepartmentIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string DepartmentId { get; set; }

	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_AccountStatusRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }

	/// <summary>
	///   昵称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_NickNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_AccountNickNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_AccountNickNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   用户名
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_AccountNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_AccountNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Username { get; set; }

	/// <summary>
	///   登录密码
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_AccountPasswordRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_AccountPasswordMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_AccountPasswordMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Password { get; set; }

	/// <summary>
	///   手机号码
	/// </summary>
	[RegularExpression(@"^1[0-9]{10}$", ErrorMessageResourceName = "Val_InvalidPhone", ErrorMessageResourceType = typeof(SharedResource))]
  public string TelPhone { get; set; }

	/// <summary>
	///   手机区号。默认 86
	/// </summary>
	public int Area { get; set; } = 86;

	/// <summary>
	///   邮箱地址
	/// </summary>
	[RegularExpression(@"^[-\w\+]+(?:\.[-\w]+)*@[-a-z0-9]+(?:\.[a-z0-9]+)*(?:\.[a-z]{2,})$", ErrorMessageResourceName = "Val_InvalidEmail", ErrorMessageResourceType = typeof(SharedResource))]
  public string Email { get; set; }

	/// <summary>
	///   头像
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_AvatarMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Avatar { get; set; }

	/// <summary>
	///   性别
	/// </summary>
	[Range(0, 2, ErrorMessageResourceName = "Val_GenderRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Sex { get; set; }

	/// <summary>
	///   岗位id
	/// </summary>
	public List<string> PostId { get; set; }
}
