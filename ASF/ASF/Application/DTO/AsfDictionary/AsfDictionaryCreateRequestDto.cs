using ASF.Resources;
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
    [Required(ErrorMessageResourceName = "Val_DictionaryCodeRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_CodeMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Code { get; set; }

    /// <summary>
    ///   字典Key
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_DictionaryKeyRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_KeyMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Key { get; set; }

    /// <summary>
    ///   字典值
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_DictionaryValueRequired", ErrorMessageResourceType = typeof(SharedResource))]
  [MaxLength(255, ErrorMessageResourceName = "Val_ValueMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Value { get; set; }

    /// <summary>
    ///   国家
    /// </summary>
    [Required(ErrorMessageResourceName = "Val_CountryNameRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string CountryCode { get; set; }

    /// <summary>
    ///   字典扩充字段
    /// </summary>
    public Dictionary<string, string> Options { get; set; }
}