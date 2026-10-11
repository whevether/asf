using Microsoft.Extensions.Localization;
using ASF.Resources;
﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASF.Domain.Services;
using ASF.Domain.Values;
using ASF.Internal.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASF.Application;

/// <summary>
/// </summary>
[Route("[controller]/[action]")]
public class UploadController : ControllerBase
{
  private readonly UploadService _uploadService;
  private readonly IStringLocalizer<SharedResource> _stringLocalizer;

  /// <summary>
  /// </summary>
  public UploadController(UploadService uploadService, IStringLocalizer<SharedResource> stringLocalizer)
  {
    _uploadService = uploadService;
    _stringLocalizer = stringLocalizer;
  }

  /// <summary>
  /// </summary>
  /// <param name="files"></param>
  /// <returns></returns>
  [HttpPost]
  public async Task<ResultList<string>> Index([FromForm] IFormCollection files)
  {
    UploadType? uploadType;
    string type = Request.Query["type"];
    if (string.IsNullOrEmpty(type))
      type = files["type"].ToString().ToLower();
    else
      type = type.ToLower();
    uploadType = (UploadType)Enum.Parse(typeof(UploadType), type);
    var fileList = new List<string>();
    foreach (var formFile in files.Files)
      using (var st = formFile.OpenReadStream())
      {
        if (formFile.Name.Equals("file"))
        {
          var file = await _uploadService
            .UploadFile(uploadType.ToString(), formFile.FileName, st, formFile.ContentType, formFile.Length);
          if (file != null)
            fileList.Add(file);
        }
        else if ( /*formFile.ContentType.ToString().Equals("image/jpeg") && */formFile.Name.Equals("img"))
        {
          if (Convert.ToInt32(st.Length / 1024) > 10 * 1024)
            return ResultList<string>.ReFailure(_stringLocalizer["uploadImageTooLarge"], 20002);
          var file = await _uploadService
            .UploadFile(uploadType.ToString(), formFile.FileName, st, formFile.ContentType, formFile.Length);
          if (file != null)
            fileList.Add(file);
        }
      }

    if (fileList.Count == 0)
      return ResultList<string>.ReFailure(_stringLocalizer["uploadFailed"], 20003);
    return ResultList<string>.ReSuccess(fileList);
  }
}