using System.Text.Json.Serialization;

namespace ASF.Domain.Values;

/// <summary>
///   ip查询转换
/// </summary>
public class IpConvertValue
{
    /// <summary>
    ///   查询ip地址
    /// </summary>
    [JsonPropertyName("query")]
  public string Query { get; set; }

    /// <summary>
    ///   查询状态
    /// </summary>
    [JsonPropertyName("status")]
  public string Status { get; set; }

    /// <summary>
    ///   国家代码
    /// </summary>
    [JsonPropertyName("countryCode")]
  public string CountryCode { get; set; }

    /// <summary>
    ///   所属国家
    /// </summary>
    [JsonPropertyName("country")]
  public string Country { get; set; }

    /// <summary>
    ///   地区编号
    /// </summary>
    [JsonPropertyName("region")]
  public string Region { get; set; }

    /// <summary>
    ///   地区名称
    /// </summary>
    [JsonPropertyName("regionName")]
  public string RegionName { get; set; }

    /// <summary>
    ///   城市名称
    /// </summary>
    [JsonPropertyName("city")]
  public string City { get; set; }

    /// <summary>
    ///   Zip
    /// </summary>
    [JsonPropertyName("zip")]
  public string Zip { get; set; }

    /// <summary>
    ///   坐标
    /// </summary>
    [JsonPropertyName("lat")]
  public decimal Lat { get; set; }

    /// <summary>
    ///   坐标
    /// </summary>
    [JsonPropertyName("lon")]
  public decimal Lon { get; set; }

    /// <summary>
    ///   时区
    /// </summary>
    [JsonPropertyName("timezone")]
  public string TimeZone { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isp")]
  public string Isp { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("org")]
  public string Org { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("as")]
  public string As { get; set; }
}
