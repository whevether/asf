using System;
using System.IO;

namespace ASF.Internal;

/// <summary>
///   缓存http 响应
/// </summary>
public class MemoryWrappedHttpResponseStream : MemoryStream
{
  private readonly Stream _innerStream;

  /// <summary>
  ///   缓存http 响应
  /// </summary>
  /// <param name="innerStream"></param>
  public MemoryWrappedHttpResponseStream(Stream innerStream)
  {
    _innerStream = innerStream ?? throw new ArgumentNullException(nameof(innerStream));
  }

  /// <summary>
  ///   推流
  /// </summary>
  public override void Flush()
  {
    _innerStream.Flush();
    base.Flush();
  }

  /// <summary>
  ///   写流
  /// </summary>
  /// <param name="buffer"></param>
  /// <param name="offset"></param>
  /// <param name="count"></param>
  public override void Write(byte[] buffer, int offset, int count)
  {
    base.Write(buffer, offset, count);
    _innerStream.Write(buffer, offset, count);
  }

  /// <summary>
  ///   销毁
  /// </summary>
  /// <param name="disposing"></param>
  protected override void Dispose(bool disposing)
  {
    base.Dispose(disposing);
    if (disposing) _innerStream.Dispose();
  }

  /// <summary>
  ///   关闭
  /// </summary>
  public override void Close()
  {
    base.Close();
    _innerStream.Close();
  }
}