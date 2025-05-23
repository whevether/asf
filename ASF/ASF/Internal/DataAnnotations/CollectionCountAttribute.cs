﻿using System.Collections;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///   Collection数量限制
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class CollectionCountAttribute : ValidationAttribute
{
    /// <summary>
    ///   List最大数量限制
    /// </summary>
    /// <param name="minCount">最小数量</param>
    /// <param name="maxCount">最大数量</param>
    public CollectionCountAttribute(int minCount, int maxCount = 10000)
  {
    MaxCount = maxCount;
    MinCount = minCount;
  }

    /// <summary>
    ///   最大数量
    /// </summary>
    public int MaxCount { get; set; }

    /// <summary>
    ///   最小数了
    /// </summary>
    public int MinCount { get; set; }

    /// <summary>
    ///   集合验证
    /// </summary>
    /// <param name="value"></param>
    /// <param name="validationContext"></param>
    /// <returns></returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
  {
    if (value == null)
      return ValidationResult.Success;
    if (value is ICollection)
    {
      var count = ((ICollection)value).Count;
      if (count > MaxCount)
        return new ValidationResult(
          string.Format("The count of {0} collections cannot be larger than {1}", validationContext.DisplayName,
            MaxCount), new[] { validationContext.MemberName });
      if (count < MinCount)
        return new ValidationResult(
          string.Format("The count of {0} collections cannot be less than {1}", validationContext.DisplayName,
            MinCount), new[] { validationContext.MemberName });
    }

    return ValidationResult.Success;
  }
}