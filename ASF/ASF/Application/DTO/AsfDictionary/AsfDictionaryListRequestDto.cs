using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.AsfDictionary;

/// <summary>
///   字典列表请求
/// </summary>
public class AsfDictionaryListRequestDto : PaginationRequestDto
{
    /// <summary>
    ///   字典Key
    /// </summary>
    [MaxLength(255, ErrorMessageResourceName = "Val_KeyMaxLength", ErrorMessageResourceType = typeof(SharedResource))]
  public string Key { get; set; }
}