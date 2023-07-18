namespace ASF.Domain.Entities
{
  /// <summary>
  /// 多语言表
  /// </summary>
  public class Translate: Entity<long>
  {
    /// <summary>
    /// 多语言名称
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 租户id
    /// </summary>
    public long? TenancyId { get; set; }
    /// <summary>
    /// 语种
    /// </summary>
    public string Languages { get; set; }

    /// <summary>
    ///  key
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// 多语言值
    /// </summary>
    public string Value { get; set; }
  }
}