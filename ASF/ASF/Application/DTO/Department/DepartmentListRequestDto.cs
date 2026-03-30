using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Department;

/// <summary>
///   部门分页请求
/// </summary>
public class DepartmentListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   部门名称
	/// </summary>
	[MinLength(2, ErrorMessageResourceName = "Val_DepartmentNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_DepartmentNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   部门状态
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_DepartmentStatusRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Status { get; set; }
}