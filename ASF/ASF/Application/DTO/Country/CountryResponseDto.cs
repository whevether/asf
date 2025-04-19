using System;

namespace ASF.Application.DTO.Country;

/// <summary>
///   国家相应
/// </summary>
public class CountryResponseDto : CountryModifyRequestDto
{
  /// <summary>
  ///   创建时间
  /// </summary>
  public DateTime CreateTime { get; set; }

  /// <summary>
  ///   创建时间
  /// </summary>
  public DateTime UpdateTime { get; set; }
}