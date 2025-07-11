using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   批量分配
/// </summary>
public class AssignIdArrayRequestDto<T>
{
  /// <summary>
  ///   id
  /// </summary>
  [Required(ErrorMessage = "权限id不能为空")]
  public string Id { get; set; }

  /// <summary>
  ///   id 数组集合
  /// </summary>
  public List<T> Ids { get; set; } = new();
}