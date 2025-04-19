namespace ASF.Internal;

/// <summary>
///   生成雪花算法id
/// </summary>
public interface IIdGenerator
{
  /// <summary>
  ///   生成ID
  /// </summary>
  /// <returns></returns>
  long GenId();
}