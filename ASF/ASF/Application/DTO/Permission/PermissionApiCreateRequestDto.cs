using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   创建权限功能api请求
/// </summary>
public class PermissionApiCreateRequestDto
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
	///   名称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_ApiNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_ApiNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_ApiNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   api 功能 状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_ApiStatusRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }

	/// <summary>
	///   api功能类型
	/// </summary>
	[Range(1, 2, ErrorMessageResourceName = "Val_ApiTypeRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Type { get; set; }

	/// <summary>
	///   api路径
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_ApiPathRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(500, ErrorMessageResourceName = "Val_ApiPathMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Path { get; set; }

	/// <summary>
	///   Http 方法
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_HttpMethodRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(30, ErrorMessageResourceName = "Val_HttpMethodMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string HttpMethods { get; set; }

	/// <summary>
	///   是否日志记录
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_ApiLogRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? IsLogger { get; set; }

	/// <summary>
	///   描述
	/// </summary>
	[MaxLength(500, ErrorMessageResourceName = "Val_DescriptionMaxLength500", ErrorMessageResourceType = typeof(SharedResource))]
  public string Description { get; set; }

	/// <summary>
	///   是否系统权限
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_IsSystemPermissionRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? IsSystem { get; set; }
}