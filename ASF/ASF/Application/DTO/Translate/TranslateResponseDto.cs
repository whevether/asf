using System;

namespace ASF.Application.DTO.Translate;

/// <summary>
///   多语言响应
/// </summary>
public class TranslateResponseDto : TranslateModifyRequestDto
{
	/// <summary>
	///   创建时间
	/// </summary>
	public DateTime CreateTime { get; set; }
}