using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   创建权限菜单
/// </summary>
public class PermissionMenuCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   权限id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_PermissionIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string PermissionId { get; set; }

	/// <summary>
	///   是否为系统菜单
	/// </summary>
	public int? IsSystem { get; set; }

	/// <summary>
	///   菜单标题
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_MenuTitleRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_MenuTitleMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_MenuTitleMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Title { get; set; }

	/// <summary>
	///   副标题
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_MenuSubTitleMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_MenuSubTitleMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Subtitle { get; set; }

	/// <summary>
	///   菜单图标
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_MenuIconRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Icon { get; set; }

	/// <summary>
	///   菜单是否隐藏
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_MenuHiddenRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? MenuHidden { get; set; }

	/// <summary>
	///   菜单内部地址
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_MenuPathMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string MenuUrl { get; set; }

	/// <summary>
	///   描述
	/// </summary>
	[MaxLength(500, ErrorMessageResourceName = "Val_MenuDescriptionMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Description { get; set; }

	/// <summary>
	///   外部链接
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_MenuExternalUrlMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string ExternalLink { get; set; }

	/// <summary>
	///   菜单重定向地址
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_MenuRedirectMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string MenuRedirect { get; set; }

	/// <summary>
	///   多语言
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_MenuLocaleMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Translate { get; set; }
}