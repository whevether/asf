using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace ASF.Application;

/// <summary>
/// </summary>
[Authorize]
[Route("[controller]/[action]")]
public class UploadController : ControllerBase
{
  private readonly IServiceProvider _serviceProvider;

  /// <summary>
  /// </summary>
  public UploadController(IServiceProvider serviceProvider)
  {
    _serviceProvider = serviceProvider;
  }

  /// <summary>
  /// </summary>
  /// <param name="files"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<ResultList<object>> Index([FromForm] IFormCollection files)
  {
    UploadType? uploadType = null;
    string type = Request.Query["type"];
    if (string.IsNullOrEmpty(type))
      type = files["type"].ToString().ToLower();
    else
      type = type.ToLower();
    uploadType = (UploadType)Enum.Parse(typeof(UploadType), type);

    if (uploadType == null)
      return ResultList<object>.ReFailure("参数错误", 20001);
    var fileList = new List<object>();
    foreach (var formFile in files.Files)
      using (var st = formFile.OpenReadStream())
      {
        if (formFile.Name.Equals("file"))
        {
          var file = await _serviceProvider.GetRequiredService<UploadService>()
            .UploadFile(uploadType.ToString(), formFile.FileName, st, formFile.ContentType, formFile.Length);
          if (file != null)
            fileList.Add(file);
        }
        else if ( /*formFile.ContentType.ToString().Equals("image/jpeg") && */formFile.Name.Equals("img"))
        {
          if (Convert.ToInt32(st.Length / 1024) > 5 * 1024)
            return ResultList<object>.ReFailure("上传失败,图片不能大于5M", 20002);
          var file = await _serviceProvider.GetRequiredService<UploadService>()
            .UploadFile(uploadType.ToString(), formFile.FileName, st, formFile.ContentType, formFile.Length);
          if (file != null)
            fileList.Add(file);
        }
      }

    if (fileList.Count == 0)
      return ResultList<object>.ReFailure("上传失败", 20003);
    return ResultList<object>.ReSuccess(fileList);
  }
}