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
	[Required(ErrorMessage = "部门名称不能为空")]
  [MinLength(2, ErrorMessage = "最少输入2个字符的部门名称")]
  [MaxLength(50, ErrorMessage = "最多输入50个字符的部门名称")]
  public string Name { get; set; }

	/// <summary>
	///   是否启用
	/// </summary>
	[Range(0, 1, ErrorMessage = "是否启用只能为0-1之间的数字")]
  public uint? Enable { get; set; }

	/// <summary>
	///   排序
	/// </summary>
	public int? Sort { get; set; }
}