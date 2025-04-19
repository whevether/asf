using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   账户分配部门
/// </summary>
public class AccountAssignDepartmentRequestDto
{
	/// <summary>
	///   账户id
	/// </summary>
	[Required(ErrorMessage = "账户id不能为空")]
  public string Id { get; set; }

	/// <summary>
	///   部门id
	/// </summary>
	[Required(ErrorMessage = "部门id不能为空")]
  public string DepartmentId { get; set; }
}