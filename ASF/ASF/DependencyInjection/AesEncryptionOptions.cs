using System;

namespace ASF.DependencyInjection;

/// <summary>
///   AES 加解密配置选项
/// </summary>
public class AesEncryptionOptions
{
  /// <summary>
  ///   是否启用 AES 加解密
  /// </summary>
  public bool Enabled { get; set; }

  /// <summary>
  ///   AES 密钥 (16/24/32 字节对应 AES-128/192/256)
  /// </summary>
  public string Key { get; set; } = string.Empty;

  /// <summary>
  ///   排除的路径，这些路径不进行加解密处理 (如: /swagger, /health)
  /// </summary>
  public string[] ExcludePaths { get; set; } = Array.Empty<string>();
}
