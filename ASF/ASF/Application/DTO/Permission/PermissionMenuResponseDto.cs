using System;

namespace ASF.Application.DTO
{
	/// <summary>
	/// 权限菜单响应
	/// </summary>
	public class PermissionMenuResponseDto: PermissionMenuModifyRequestDto
	{
		/// <summary>
		/// key
		/// </summary>
		public long Key { get; set; }

		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime CreateTime { get; set; }
	}
}