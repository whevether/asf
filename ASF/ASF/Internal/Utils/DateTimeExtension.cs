namespace System;

/// <summary>
///   时间扩展
/// </summary>
public static class DateTimeExtension
{
  /// <summary>
  ///   转换为毫秒时间戳
  /// </summary>
  /// <param name="date"></param>
  /// <returns></returns>
  public static long ToUnixTime64(this DateTime date)
  {
    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalMilliseconds);
  }

  /// <summary>
  ///   转换为秒级时间戳
  /// </summary>
  /// <param name="date"></param>
  /// <returns></returns>
  public static int ToUnixTime32(this DateTime date)
  {
    var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    return Convert.ToInt32((date.ToUniversalTime() - epoch).TotalSeconds);
  }

  /// <summary>
  ///   生成随机字符串
  /// </summary>
  /// <param name="codeCount"></param>
  /// <returns></returns>
  public static string GenerateCheckCode(int codeCount)
  {
    var rep = 0;
    var str = string.Empty;
    var num2 = DateTime.Now.Ticks + rep;
    rep++;
    var random = new Random((int)((ulong)num2 & 0xffffffffL) | (int)(num2 >> rep));
    for (var i = 0; i < codeCount; i++)
    {
      char ch;
      var num = random.Next();
      if (num % 2 == 0)
        ch = (char)(0x30 + (ushort)(num % 10));
      else
        ch = (char)(0x41 + (ushort)(num % 0x1a));
      str = str + ch;
    }

    return str;
  }

  /// <summary>
  ///   时间戳Timestamp转换成日期
  /// </summary>
  /// <param name="timeStamp"></param>
  /// <returns></returns>
  public static DateTime ConvertDateTime(this long timeStamp)
  {
    var dtStart = TimeZoneInfo.ConvertTime(new DateTime(1970, 1, 1, 8, 0, 0), TimeZoneInfo.Utc);
    var lTime = timeStamp * 10000000;
    var toNow = new TimeSpan(lTime);
    var date = dtStart.Add(toNow);
    return date;
  }
}