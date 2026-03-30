using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   api分页请求
/// </summary>
public class PermissionApiListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   权限id
	/// </summary>
	public string PermissionId { get; set; }

	/// <summary>
	///   权限功能类型
	/// </summary>
	[Range(1, 2, ErrorMessageResourceName = "Val_ApiTypeRange12", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Type { get; set; }

	/// <summary>
	///   权限功能状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_ApiStatus01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }

	/// <summary>
	///   权限功能名称
	/// </summary>
	[MinLength(1, ErrorMessageResourceName = "Val_ApiNameMinLength1", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_ApiNameMaxLength50", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   api请求方法
	/// </summary>
	[MinLength(1, ErrorMessageResourceName = "Val_HttpMethodMinLength1", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(5, ErrorMessageResourceName = "Val_HttpMethodMaxLength5", ErrorMessageResourceType = typeof(SharedResource))]
  public string HttpMethod { get; set; }

	/// <summary>
	///   api请求路径
	/// </summary>
	[MinLength(1, ErrorMessageResourceName = "Val_ApiPathMinLength1", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(100, ErrorMessageResourceName = "Val_ApiPathMaxLength100", ErrorMessageResourceType = typeof(SharedResource))]
  public string Path { get; set; }
}