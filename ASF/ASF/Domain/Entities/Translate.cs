using System;

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
    /// 国家
    /// </summary>
    public string Country { get; set; }
    /// <summary>
    /// 国家语言code 利用国家code 分组 例如zh en 等等
    /// </summary>
    public string CountryCode { get; set; }
    /// <summary>
    ///   国家id
    /// </summary>
    public long CountryId { get; set; }
    /// <summary>
    ///  多语言 key 例如 sex.max
    /// </summary>
    public string Key { get; set; }
    /// <summary>
    /// 多语言值内容 例如 男
    /// </summary>
    public string Value { get; set; }
    /// <summary>
    /// 添加者
    /// </summary>
    public string AddUser { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }
  }
}