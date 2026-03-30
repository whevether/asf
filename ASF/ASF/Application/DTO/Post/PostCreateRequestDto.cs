using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Post;

/// <summary>
///   创建岗位请求
/// </summary>
public class PostCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   岗位名
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_PostNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_PostNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_PostNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   排序
	/// </summary>
	[Range(0, 100, ErrorMessageResourceName = "Val_SortRange100", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Sort { get; set; }

	/// <summary>
	///   岗位状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_StateRange01", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Enable { get; set; }

	/// <summary>
	///   岗位描述
	/// </summary>
	[MaxLength(255, ErrorMessageResourceName = "Val_PostDescriptionMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Description { get; set; }
}