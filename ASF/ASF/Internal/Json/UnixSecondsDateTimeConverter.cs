using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ASF.Internal.Json;

/// <summary>
///   DateTime ↔ Unix 秒（数字），对齐原 MyUnixDateTimeConverter。
/// </summary>
public sealed class UnixSecondsDateTimeConverter : JsonConverter<DateTime>
{
  internal static readonly DateTime UnixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

  /// <inheritdoc />
  public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt64(out var sec))
      return UnixEpoch.AddSeconds(sec);
    if (reader.TokenType == JsonTokenType.String)
    {
      var s = reader.GetString();
      if (long.TryParse(s, out var fromString))
        return UnixEpoch.AddSeconds(fromString);
      if (DateTime.TryParse(s, out var dt))
        return dt;
    }
    throw new JsonException("Expected unix seconds for DateTime.");
  }

  /// <inheritdoc />
  public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
  {
    var seconds = value == DateTime.MinValue
      ? 0L
      : (long)(value.ToUniversalTime() - UnixEpoch).TotalSeconds;
    writer.WriteNumberValue(seconds);
  }
}

/// <summary>
///   DateTime? ↔ Unix 秒
/// </summary>
public sealed class UnixSecondsNullableDateTimeConverter : JsonConverter<DateTime?>
{
  /// <inheritdoc />
  public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    if (reader.TokenType == JsonTokenType.Null)
      return null;
    return new UnixSecondsDateTimeConverter().Read(ref reader, typeof(DateTime), options);
  }

  /// <inheritdoc />
  public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
  {
    if (value == null)
    {
      writer.WriteNullValue();
      return;
    }
    new UnixSecondsDateTimeConverter().Write(writer, value.Value, options);
  }
}
