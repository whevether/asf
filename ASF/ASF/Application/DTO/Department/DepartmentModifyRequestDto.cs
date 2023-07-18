using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASF.Application.DTO.Department
{
	/// <summary>
	/// 修改部门
	/// </summary>
	public class DepartmentModifyRequestDto: DepartmentCreateRequestDto
	{
		/// <summary>
		/// 部门id
		/// </summary>
		public string Id { get; set; }
		/// <summary>
		/// 角色id 集合
		/// </summary>
		[NotMapped]
		public List<string> RoleIds { get; set; }
	}
}