using System.ComponentModel.DataAnnotations;

namespace ASF.Application.DTO;

/// <summary>
///   修改权限功能api请求
/// </summary>
public class PermissionApiModifyRequestDto : PermissionApiCreateRequestDto
{
  /// <summary>
  ///   权限功能Id
  /// </summary>
  [Required(ErrorMessage = "授权api id不能为空")]
  public string Id { get; set; }
}