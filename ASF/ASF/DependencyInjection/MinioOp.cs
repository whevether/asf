namespace ASF.DependencyInjection;

/// <summary>
///   minio配置
/// </summary>
public class MinioOp
{
  /// <summary>
  ///   minio url地址
  /// </summary>
  public string MinioUrl { get; set; }

  /// <summary>
  /// </summary>
  public string Endpoint { get; set; }

  /// <summary>
  /// </summary>
  public string AccessKey { get; set; }

  /// <summary>
  /// </summary>
  public string SecretKey { get; set; }
}