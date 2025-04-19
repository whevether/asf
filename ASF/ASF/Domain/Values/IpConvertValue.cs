using Newtonsoft.Json;

namespace ASF.Domain.Values;

/// <summary>
///   ip查询转换
/// </summary>
public class IpConvertValue
{
  /// <summary>
  ///   查询ip地址
  /// </summary>
  [JsonProperty("query")]
  public string Query { get; set; }

  /// <summary>
  ///   查询状态
  /// </summary>
  [JsonProperty("status")]
  public string Status { get; set; }

  /// <summary>
  ///   国家代码
  /// </summary>
  [JsonProperty("countryCode")]
  public string CountryCode { get; set; }

  /// <summary>
  ///   所属国家
  /// </summary>
  [JsonProperty("country")]
  public string Country { get; set; }

  /// <summary>
  ///   地区编号
  /// </summary>
  [JsonProperty("region")]
  public string Region { get; set; }

  /// <summary>
  ///   地区名称
  /// </summary>
  [JsonProperty("regionName")]
  public string RegionName { get; set; }

  /// <summary>
  ///   城市名称
  /// </summary>
  [JsonProperty("city")]
  public string City { get; set; }

  /// <summary>
  ///   Zip
  /// </summary>
  [JsonProperty("zip")]
  public string Zip { get; set; }

  /// <summary>
  ///   坐标
  /// </summary>
  [JsonProperty("lat")]
  public decimal Lat { get; set; }

  /// <summary>
  ///   坐标
  /// </summary>
  [JsonProperty("lon")]
  public decimal Lon { get; set; }

  /// <summary>
  ///   时区
  /// </summary>
  [JsonProperty("timezone")]
  public string TimeZone { get; set; }

  /// <summary>
  /// </summary>
  [JsonProperty("isp")]
  public string Isp { get; set; }

  /// <summary>
  /// </summary>
  [JsonProperty("org")]
  public string Org { get; set; }

  /// <summary>
  /// </summary>
  [JsonProperty("as")]
  public string As { get; set; }
}