using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改状态
/// </summary>
public class ModifyStatusRequestDto
{
  /// <summary>
  ///   id
  /// </summary>
  [Required(ErrorMessage = "id不能为空")]
  public string Id { get; set; }

  /// <summary>
  ///   状态
  /// </summary>
  public uint Status { get; set; }
}