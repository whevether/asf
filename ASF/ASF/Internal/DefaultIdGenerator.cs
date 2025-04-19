using System;
using IdGen;

namespace ASF.Internal;

/// <summary>
///   生成雪花算法id
/// </summary>
public class DefaultIdGenerator : IIdGenerator
{
  /// <summary>
  ///   雪花算法id
  /// </summary>
  private readonly IdGenerator generator;

  /// <summary>
  ///   生成雪花算法id
  /// </summary>
  public DefaultIdGenerator()
  {
    GeneratorId = new Random().Next(0, 1023);
    // Let's say we take april 1st 2015 as our epoch
    var epoch = new DateTime(2020, 4, 1, 0, 0, 0, DateTimeKind.Utc);
    // Create a mask configuration of 45 bits for timestamp, 2 for generator-id 
    // and 16 for sequence
    var mc = new IdStructure(41, 10, 12);
    // Create an IdGenerator with it's generator-id set to 0, our custom epoch 
    // and mask configuration
    var options = new IdGeneratorOptions(mc, new DefaultTimeSource(epoch));
    generator = new IdGenerator(GeneratorId, options);
  }

  /// <summary>
  ///   生成id
  /// </summary>
  public static int GeneratorId { get; private set; } = -1;

  /// <summary>
  ///   生成id
  /// </summary>
  /// <returns></returns>
  public long GenId()
  {
    if (generator == null)
      throw new ArgumentNullException("1024 GeneratorIds have been allocated");
    return generator.CreateId();
  }
}