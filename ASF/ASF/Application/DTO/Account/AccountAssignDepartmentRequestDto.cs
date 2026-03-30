using ASF.Resources;
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
	[Required(ErrorMessageResourceName = "Val_AccountIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   部门id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_DepartmentIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string DepartmentId { get; set; }
}