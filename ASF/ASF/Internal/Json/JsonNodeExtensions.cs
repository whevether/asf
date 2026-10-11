using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ASF.Internal.Json;

/// <summary>
///   JsonNode 取值，对齐原 Newtonsoft Value&lt;T&gt;。
/// </summary>
public static class JsonNodeExtensions
{
  /// <summary>
  ///   读取整数，失败返回 null
  /// </summary>
  public static int? AsInt(this JsonNode node)
  {
    if (node == null || node.GetValueKind() == JsonValueKind.Null)
      return null;
    try
    {
      return node.GetValue<int>();
    }
    catch
    {
      return int.TryParse(node.ToString(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var n)
        ? n
        : null;
    }
  }

  /// <summary>
  ///   读取布尔，失败返回 null
  /// </summary>
  public static bool? AsBool(this JsonNode node)
  {
    if (node == null || node.GetValueKind() == JsonValueKind.Null)
      return null;
    switch (node.GetValueKind())
    {
      case JsonValueKind.True:
        return true;
      case JsonValueKind.False:
        return false;
      case JsonValueKind.Number:
        return node.AsInt() != 0;
      case JsonValueKind.String:
        var s = node.GetValue<string>();
        if (s == "1" || string.Equals(s, "true", StringComparison.OrdinalIgnoreCase))
          return true;
        if (s == "0" || string.Equals(s, "false", StringComparison.OrdinalIgnoreCase))
          return false;
        return null;
      default:
        return null;
    }
  }

  /// <summary>
  ///   读取字符串
  /// </summary>
  public static string AsString(this JsonNode node)
  {
    if (node == null || node.GetValueKind() == JsonValueKind.Null)
      return null;
    if (node.GetValueKind() == JsonValueKind.String)
      return node.GetValue<string>();
    return node.ToString();
  }
}
