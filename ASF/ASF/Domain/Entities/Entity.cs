namespace ASF.Domain.Entities;
/// <summary>
/// 实体类
/// </summary>
/// <typeparam name="T"></typeparam>
public class Entity<T>
{
  /// <summary>
  /// id
  /// </summary>
  public T Id { get; private set; }
  /// <summary>
  /// 设置id
  /// </summary>
  /// <param name="id"></param>
  public void SetId(T id)
  {
    this.Id = id;
  }
}