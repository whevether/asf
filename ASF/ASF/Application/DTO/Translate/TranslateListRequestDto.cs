using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Translate;

/// <summary>
///   多语言分页请求
/// </summary>
public class TranslateListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   多语言名称
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_TranslateNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_TranslateNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }
}