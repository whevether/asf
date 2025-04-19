using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Tenancy;

/// <summary>
///   修改租户
/// </summary>
public class TenancyModifyRequestDto : TenancyCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	[Required(ErrorMessage = "租户id不能为空")]
  public string Id { get; set; }
}