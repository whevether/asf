using System;
using System.ComponentModel.DataAnnotations;

namespace ASF.Domain.Values;

/// <summary>
///   手机号码
/// </summary>
public class PhoneNumber : IEquatable<PhoneNumber>, IValueObject
{
  /// <summary>
  ///   手机号码
  /// </summary>
  /// <param name="number"></param>
  /// <param name="areacode"></param>
  public PhoneNumber(string number, int areacode = 86)
  {
    Number = number;
    AreaCode = areacode;
  }

  /// <summary>
  ///   手机号码
  /// </summary>
  /// <param name="phoneNumber"></param>
  public PhoneNumber(string phoneNumber)
  {
    if (!string.IsNullOrEmpty(phoneNumber))
    {
      var data = phoneNumber.Split('+');
      if (data.Length != 2) Number = "";
      if (data.Length > 0)
        Number = data[1];
      if (data.Length > 1)
        AreaCode = int.Parse(data[0]);
    }
  }

  /// <summary>
  ///   手机号码
  /// </summary>
  [MaxLength(20)]
  public string Number { get; }

  /// <summary>
  ///   手机号码区号
  /// </summary>
  public int AreaCode { get; }

  /// <summary>
  ///   比对
  /// </summary>
  /// <param name="other"></param>
  /// <returns></returns>
  public bool Equals(PhoneNumber other)
  {
    if (AreaCode != other.AreaCode)
      return false;
    if (Number != other.Number)
      return false;
    return true;
  }

  /// <summary>
  ///   重载字符串
  /// </summary>
  /// <returns></returns>
  public override string ToString()
  {
    return AreaCode + "+" + Number;
  }

  /// <summary>
  ///   浅复制
  /// </summary>
  /// <returns></returns>
  public PhoneNumber Clone()
  {
    return new PhoneNumber(Number, AreaCode);
  }
}