using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   富文本分页请求
/// </summary>
public class EditorListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   用户名
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_PageNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_PageNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   手机号码
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_PageTypeRange", ErrorMessageResourceType = typeof(SharedResource))]
  public int? Type { get; set; }
}