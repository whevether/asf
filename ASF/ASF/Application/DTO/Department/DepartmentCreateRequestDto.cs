using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Department;

/// <summary>
///   创建部门
/// </summary>
public class DepartmentCreateRequestDto
{
	/// <summary>
	///   租户id
	/// </summary>
	public string TenancyId { get; set; }

	/// <summary>
	///   父id
	/// </summary>
	public string Pid { get; set; }

	/// <summary>
	///   部门名称
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_DepartmentNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MinLength(2, ErrorMessageResourceName = "Val_DepartmentNameMinLength", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(50, ErrorMessageResourceName = "Val_DepartmentNameMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Name { get; set; }

	/// <summary>
	///   是否启用
	/// </summary>
	[Range(0, 1, ErrorMessageResourceName = "Val_EnabledRange", ErrorMessageResourceType = typeof(SharedResource))]
  public uint? Enable { get; set; }

	/// <summary>
	///   排序
	/// </summary>
	public int? Sort { get; set; }
}