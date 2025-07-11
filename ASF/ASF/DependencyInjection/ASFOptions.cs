namespace ASF.DependencyInjection;

/// <summary>
///   asf 配置
/// </summary>
public class ASFOptions
{
  /// <summary>
  ///   数据库连接字符串
  /// </summary>
  public string DBConnectionString { get; set; }

  /// <summary>
  ///   数据库类型
  /// </summary>
  public string DBType { get; set; }
}