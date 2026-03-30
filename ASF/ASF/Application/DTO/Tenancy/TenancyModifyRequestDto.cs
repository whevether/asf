using ASF.Resources;
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
	[Required(ErrorMessageResourceName = "Val_TenancyIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }
}