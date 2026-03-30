using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   管理员身份验证请求
/// </summary>
public class AuthoriseByUsernameRequestDto
{
    /// <summary>
    ///   登录类型
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_LoginTypeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string LoginType { get; set; }

    /// <summary>
    ///   租户id
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_TenancyIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string TenancyId { get; set; }

    /// <summary>
    ///   用户名
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_UserNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [StringLength(32, MinimumLength = 2, ErrorMessageResourceName = "Val_UserNameLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Username { get; set; }

    /// <summary>
    ///   登录密码
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_LoginPasswordRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [StringLength(32, MinimumLength = 5, ErrorMessageResourceName = "Val_PasswordLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Password { get; set; }
}
