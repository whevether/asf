using System.Collections.Generic;

namespace ASF.Application.DTO;

/// <summary>
///   id 集合请求
/// </summary>
/// <typeparam name="T"></typeparam>
public class IdArrayRequestDto<T>
{
	/// <summary>
	///   id 数组集合
	/// </summary>
	public List<T> Ids { get; set; }
}