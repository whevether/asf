using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO
{
	/// <summary>
	/// 修改权限菜单
	/// </summary>
	public class PermissionMenuModifyRequestDto: PermissionMenuCreateRequestDto
	{
		/// <summary>
		/// 唯一标示
		/// </summary>
		[Required(ErrorMessage = "菜单id不能为空")]
		public string Id { get;  set; }
	}
}