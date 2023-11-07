using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Translate
{
	/// <summary>
	/// 创建多语言
	/// </summary>
	public class TranslateCreateRequestDto
	{
		/// <summary>
		/// 租户id
		/// </summary>
		public string TenancyId { get; set; }
		/// <summary>
		/// 多语言名称
		/// </summary>
		[Required(ErrorMessage = "多语言名称不能为空"),MinLength(2,ErrorMessage = "多语言名称最少输入2个字符"),MaxLength(50,ErrorMessage = "多语言名字最多输入50个字符")]
		public string Name { get; set; }
		/// <summary>
		/// 国家
		/// </summary>
		[Required(ErrorMessage = "国家名称不能为空")]
		public string Country { get; set; }
		/// <summary>
		/// 国家语言code 利用国家code 分组 例如zh en 等等
		/// </summary>
		[Required(ErrorMessage = "国家code不能为空")]
		public string CountryCode { get; set; }
		/// <summary>
		///   国家id
		/// </summary>
		[Required(ErrorMessage = "国家Id不能为空")]
		public string CountryId { get; set; }
		/// <summary>
		/// 多语言key
		/// </summary>
		[Required(ErrorMessage = "多语言key不能为空"),MinLength(2,ErrorMessage = "多语言key最少输入2个字符"),MaxLength(500,ErrorMessage = "多语言key最多输入500个字符")]
		public string Key { get; set; }
		/// <summary>
		/// 多语言值
		/// </summary>
		[Required(ErrorMessage = "多语言值不能为空"),MinLength(2,ErrorMessage = "多语言值最少输入2个字符"),MaxLength(5000,ErrorMessage = "多语言值最多输入5000个字符")]
		public string Value { get; set; }
	}
}