using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.AsfDictionary;

/// <summary>
///   创建字典请求
/// </summary>
public class AsfDictionaryCreateRequestDto
{
    /// <summary>
    ///   租户id
    /// </summary>
    public string TenancyId { get; set; }

    /// <summary>
    ///   字典编码
    /// </summary>
    [Required(ErrorMessage = "字典编码不能为空")]
  [MaxLength(255, ErrorMessage = "最多输入255个编码字符")]
  public string Code { get; set; }

    /// <summary>
    ///   字典Key
    /// </summary>
    [Required(ErrorMessage = "字典key不能为空")]
  [MaxLength(255, ErrorMessage = "最多输入255个key字符")]
  public string Key { get; set; }

    /// <summary>
    ///   字典值
    /// </summary>
    [Required(ErrorMessage = "字典值不能为空")]
  [MaxLength(255, ErrorMessage = "最多输入255个值字符")]
  public string Value { get; set; }

    /// <summary>
    ///   国家
    /// </summary>
    [Required(ErrorMessage = "国家名称不能为空")]
  public string Country { get; set; }

  /// <summary>
  ///   国家id
  /// </summary>
  [Required(ErrorMessage = "国家Id不能为空")]
  public string CountryId { get; set; }

  /// <summary>
  ///   字典扩充字段
  /// </summary>
  public Dictionary<string, string> Options { get; set; }
}