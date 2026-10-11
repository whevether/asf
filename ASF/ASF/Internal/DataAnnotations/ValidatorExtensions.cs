using System.Collections.Generic;
using System.Linq;
using System.Net;
using ASF.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;

namespace System.ComponentModel.DataAnnotations;

/// <summary>
///   验证扩展
/// </summary>
public static class ValidatorExtensions
{
    /// <summary>
    ///   获取验证返回信息集合
    /// </summary>
    /// <param name="dictionary"></param>
    /// <returns></returns>
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
  {
    return dictionary.SelectMany(m => m.Value.Errors)
      .Select(m => m.ErrorMessage)
      .ToList();
  }
}

/// <summary>
///   模型验证
/// </summary>
public class ValidationActionFilter : ActionFilterAttribute
{
    /// <summary>
    ///   执行验证输出
    /// </summary>
    /// <param name="context"></param>
    public override void OnActionExecuting(ActionExecutingContext context)
  {
    var modelState = context.ModelState;
    string result = null;
    if (!modelState.IsValid)
    {
      var rawMessage = modelState.GetErrorMessages()[0];
      var localizer = context.HttpContext.RequestServices.GetService<IStringLocalizer<SharedResource>>();
      var message = localizer != null ? localizer[rawMessage].Value : rawMessage;
      context.Result = new JsonResult(new
      {
        data = result,
        status = HttpStatusCode.BadRequest,
        message = message
      })
      {
        StatusCode = (int)HttpStatusCode.BadRequest
      };
    }
  }
}