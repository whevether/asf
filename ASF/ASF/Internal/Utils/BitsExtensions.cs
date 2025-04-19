using System;

namespace ASF.Internal.Utils;

internal static class BitsExtensions
{
  /*
   * value = Byte:   (value & (value - Byte1))   =  Int32;
   * value = UInt16: (value & (value - UShort1)) =  Int32;
   * value = UInt32: (value & (value - 1U))      = UInt32;
   * value = UInt64: (value & (value - 1UL))     = UInt64;
   */

  private const byte Byte0 = byte.MinValue;
  private const byte Byte1 = 1;

  private const ushort UShort0 = ushort.MinValue;
  private const ushort UShort1 = 1;

  private static byte ClearLeast(byte value)
  {
    return (byte)(value & (value - Byte1));
  }

  private static ushort ClearLeast(ushort value)
  {
    return (ushort)(value & (value - UShort1));
  }

  private static uint ClearLeast(uint value)
  {
    return value & (value - 1U);
  }

  private static ulong ClearLeast(ulong value)
  {
    return value & (value - 1UL);
  }

  public static int Count(byte value)
  {
    var count = 0;
    while (value != Byte0)
    {
      count++;
      value = (byte)(value & (value - Byte1));
    }

    return count;
  }

  public static int Count(ushort value)
  {
    var count = 0;
    while (value != UShort0)
    {
      count++;
      value = (ushort)(value & (value - UShort1));
    }

    return count;
  }

  public static int Count(uint value)
  {
    var count = 0;
    while (value != 0U)
    {
      count++;
      value = value & (value - 1U);
    }

    return count;
  }

  public static int Count(ulong value)
  {
    var count = 0;
    while (value != 0UL)
    {
      count++;
      value = value & (value - 1UL);
    }

    return count;
  }

  public static byte[] GetOnes(byte value)
  {
    var index = 0;
    byte temp;
    var temps = new byte[0x08];

    while (value != UShort0)
    {
      // 消掉最后一个1之前
      temp = value;
      // 消掉最后一个1之后
      value = (byte)(value & (value - Byte1));
      // 记录差值
      temps[index++] = (byte)(temp - value);
    }

    var result = new byte[index];
    for (var i = 0; i < index; i++) result[i] = temps[i];
    return result;
  }

  public static ushort[] GetOnes(ushort value)
  {
    var index = 0;
    ushort temp;
    var temps = new ushort[0x10];

    while (value != UShort0)
    {
      // 消掉最后一个1之前
      temp = value;
      // 消掉最后一个1之后
      value = (ushort)(value & (value - UShort1));
      // 记录差值
      temps[index++] = (ushort)(temp - value);
    }

    var result = new ushort[index];
    for (var i = 0; i < index; i++) result[i] = temps[i];
    return result;
  }

  public static uint[] GetOnes(this uint value)
  {
    var index = 0;
    uint temp;
    var temps = new uint[0x20];

    while (value != 0U)
    {
      // 消掉最后一个1之前
      temp = value;
      // 消掉最后一个1之后
      value = value & (value - 1U);
      // 记录差值
      temps[index++] = temp - value;
    }

    var result = new uint[index];
    for (var i = 0; i < index; i++) result[i] = temps[i];
    return result;
  }

  public static ulong[] GetOnes(ulong value)
  {
    var index = 0;
    ulong temp;
    var temps = new ulong[0x40];

    while (value != 0UL)
    {
      // 消掉最后一个1之前
      temp = value;
      // 消掉最后一个1之后
      value = value & (value - 1UL);
      // 记录差值
      temps[index++] = temp - value;
    }

    var result = new ulong[index];
    for (var i = 0; i < index; i++) result[i] = temps[i];
    return result;
  }

  public static bool ExactlyOne(byte value)
  {
    return value != Byte0 && (value & (value - Byte1)) == 0;
  }

  public static bool ExactlyOne(ushort value)
  {
    return value != UShort0 && (value & (value - UShort1)) == 0;
  }

  public static bool ExactlyOne(uint value)
  {
    return value != 0U && (value & (value - 1U)) == 0U;
  }

  public static bool ExactlyOne(ulong value)
  {
    return value != 0UL && (value & (value - 1U)) == 0UL;
  }

  public static bool MoreThanOne(byte value)
  {
    return (value & (value - Byte1)) != 0;
  }

  public static bool MoreThanOne(ushort value)
  {
    return (value & (value - UShort1)) != 0;
  }

  public static bool MoreThanOne(uint value)
  {
    return (value & (value - 1U)) != 0U;
  }

  public static bool MoreThanOne(ulong value)
  {
    return (value & (value - 1UL)) != 0UL;
  }

  public static sbyte[] GetOnes(sbyte value)
  {
    var ones = GetOnes((byte)value);

    var length = ones.Length;
    var result = new sbyte[length];
    for (var i = 0; i < length; i++)
      result[i] = (sbyte)ones[i];

    return result;
  }

  public static short[] GetOnes(short value)
  {
    var ones = GetOnes((ushort)value);

    var length = ones.Length;
    var result = new short[length];
    for (var i = 0; i < length; i++)
      result[i] = (short)ones[i];

    return result;
  }

  public static int[] GetOnes(this int value)
  {
    var ones = GetOnes((uint)value);

    var length = ones.Length;
    var result = new int[length];
    for (var i = 0; i < length; i++)
      result[i] = (int)ones[i];

    return result;
  }

  public static long[] GetOnes(long value)
  {
    var ones = GetOnes((ulong)value);

    var length = ones.Length;
    var result = new long[length];
    for (var i = 0; i < length; i++)
      result[i] = (long)ones[i];

    return result;
  }

  public static int CompareTimestamp(this byte[] @this, byte[] other)
  {
    var length = @this.Length;
    if (other.Length != length)
      throw new NotSupportedException();

    for (var i = 0; i < length; i++)
    {
      if (@this[i] > other[i])
        return 1;
      if (@this[i] < other[i])
        return -1;
    }

    return 0;
  }

  public static long ToInt64WithBigEndian(this byte[] timestamp)
  {
    var high = (timestamp[0] << 0x18) | (timestamp[1] << 0x10) | (timestamp[2] << 8) | timestamp[3];
    var low = (timestamp[4] << 0x18) | (timestamp[5] << 0x10) | (timestamp[6] << 8) | timestamp[7];

    return ((long)high << 0x20) | (uint)low;
  }
}