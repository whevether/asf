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
  [Required(ErrorMessage = "账户id不能为空")]
  public string Id { get; set; }

  /// <summary>
  ///   手机区号 默认 86
  /// </summary>
  public int Area { get; set; } = 86;

  /// <summary>
  ///   新手机号码
  /// </summary>
  [RegularExpression(@"^1[0-9]{10}$", ErrorMessage = "手机号码不正确")]
  public string NewTelPhone { get; set; }
}