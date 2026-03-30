using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Post;

/// <summary>
///   岗位分页请求
/// </summary>
public class PostListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   岗位名称
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_PostNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_PostNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   岗位状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_PostStatusRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }
}