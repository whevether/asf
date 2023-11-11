using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO.Country;
/// <summary>
/// 修改国家
/// </summary>
public class CountryModifyRequestDto: CountryCreateRequestDto
{
  /// <summary>
  /// ID
  /// </summary>
  [Required(ErrorMessage = "国家id不能为空")]
  public string Id { get; set; }
}