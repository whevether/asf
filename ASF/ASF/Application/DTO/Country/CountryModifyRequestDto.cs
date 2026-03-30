using ASF.Resources;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Country;

/// <summary>
///   修改国家
/// </summary>
public class CountryModifyRequestDto : CountryCreateRequestDto
{
  /// <summary>
  ///   ID
  /// </summary>
  [Required(ErrorMessageResourceName = "Val_CountryIdRequired", ErrorMessageResourceType = typeof(SharedResource))]
  public string Id { get; set; }
}