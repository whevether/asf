using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改权限菜单
/// </summary>
public class PermissionMenuModifyRequestDto : PermissionMenuCreateRequestDto
{
	/// <summary>
	///   唯一标示
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_MenuIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }
}