using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改状态
/// </summary>
public class ModifyStatusRequestDto
{
	/// <summary>
	///   id
	/// </summary>
	[Required(ErrorMessageResourceName = "Val_IdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }

	/// <summary>
	///   状态
	/// </summary>
	public uint Status { get; set; }
}