using ASF.Domain.Values;

namespace ASF.Application.DTO;

/// <summary>
///   审计分页请求
/// </summary>
public class AudioListRequestDto : PaginationRequestDto
{
	/// <summary>
	///   日志类型
	/// </summary>
	public LoggingType LogType { get; set; }

	/// <summary>
	///   操作账户名
	/// </summary>
	public string AccountName { get; set; }
}