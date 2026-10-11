using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASF.Internal.Json;

/// <summary>
///   全局 JSON 契约：camelCase + Unix 秒时间戳。MVC 与手写序列化必须共用。
/// </summary>
public static class AsfJson
{
  /// <summary>
  ///   默认序列化选项
  /// </summary>
  public static readonly JsonSerializerOptions Default = CreateOptions();

  /// <summary>
  ///   创建与 MVC 一致的选项副本
  /// </summary>
  public static JsonSerializerOptions CreateOptions()
  {
    var options = new JsonSerializerOptions
    {
      PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
      PropertyNameCaseInsensitive = true,
      DefaultIgnoreCondition = JsonIgnoreCondition.Never
    };
    options.Converters.Add(new UnixSecondsDateTimeConverter());
    options.Converters.Add(new UnixSecondsNullableDateTimeConverter());
    return options;
  }

  /// <summary>
  ///   序列化
  /// </summary>
  public static string Serialize(object value)
  {
    return JsonSerializer.Serialize(value, Default);
  }

  /// <summary>
  ///   反序列化
  /// </summary>
  public static T Deserialize<T>(string json)
  {
    return JsonSerializer.Deserialize<T>(json, Default);
  }
}
