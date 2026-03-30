using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   权限菜单列表请求
/// </summary>
public class PermissionMenuListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   权限id
	/// </summary>
	public string PermissionId { get; set; }

	/// <summary>
	///   权限菜单标题
	/// </summary>
	[MinLength(1, ErrorMessageResourceName = "Val_MenuTitleMinLength1", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_MenuTitleMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Title { get; set; }

	/// <summary>
	///   权限菜单地址
	/// </summary>
	[MinLength(1, ErrorMessageResourceName = "Val_MenuPathMinLength1", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_MenuPathMaxLength255", ErrorMessageResourceType = typeof(SharedResource))]
  public string MenuUrl { get; set; }
}