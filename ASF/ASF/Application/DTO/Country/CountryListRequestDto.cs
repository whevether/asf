namespace ASF.Application.DTO.Country;
/// <summary>
/// 国家列表请求
/// </summary>
public class CountryListRequestDto: PaginationRequestDto
{
  /// <summary>
  /// 国家名称或国家code
  /// </summary>
  public string Name { get; set; }
}