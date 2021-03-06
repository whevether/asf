using System;

namespace ASF.Application.DTO.Editor
{
	/// <summary>
	/// 富文本列表响应
	/// </summary>
	public class EditorResponseDto
	{
		/// <summary>
		/// id
		/// </summary>
		public long Id { get; set; }
		/// <summary>
		/// 富文本名称
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// 富文本类型
		/// </summary>
		public uint Type { get; set; }
		/// <summary>
		/// 生成html路径
		/// </summary>
		public string Path { get; set; }
		/// <summary>
		/// 轮播图集合
		/// </summary>
		public string Banner { get; set; }
		/// <summary>
		/// 原始网页
		/// </summary>
		public string OldContent { get; set; }
		/// <summary>
		/// 新网页
		/// </summary>
		public string NewContent { get; set; }
		/// <summary>
		/// 创建时间
		/// </summary>
		public DateTime CreateTime { get; set; }
	}
}