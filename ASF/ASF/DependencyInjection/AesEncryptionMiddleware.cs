using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ASF.Internal.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace ASF.DependencyInjection;

/// <summary>
///   AES 加解密中间件
///   请求：对 params 和 data 参数进行 AES 解密
///   响应：对返回数据统一进行 AES 加密
/// </summary>
public class AesEncryptionMiddleware
{
  private readonly RequestDelegate _next;
  private readonly ILogger<AesEncryptionMiddleware> _logger;
  private readonly AesEncryptionOptions _options;
  /// <summary>
  /// 
  /// </summary>
  /// <param name="next"></param>
  /// <param name="options"></param>
  /// <param name="logger"></param>
  public AesEncryptionMiddleware(RequestDelegate next, IOptions<AesEncryptionOptions> options,
    ILogger<AesEncryptionMiddleware> logger)
  {
    _next = next;
    _logger = logger;
    _options = options?.Value ?? new AesEncryptionOptions();
  }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="context"></param>
  public async Task Invoke(HttpContext context)
  {
    if (!_options.Enabled || string.IsNullOrEmpty(_options.Key))
    {
      await _next(context);
      return;
    }

    var path = context.Request.Path.Value ?? string.Empty;
    if (_options.ExcludePaths?.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)) == true)
    {
      await _next(context);
      return;
    }

    // 解密请求参数
    await DecryptRequestAsync(context);

    // 包装响应流以加密输出
    var originalBodyStream = context.Response.Body;
    await using var memoryStream = new MemoryStream();
    context.Response.Body = memoryStream;

    try
    {
      await _next(context);

      // 加密响应
      memoryStream.Position = 0;
      var responseBody = await new StreamReader(memoryStream).ReadToEndAsync();
      context.Response.Body = originalBodyStream;

      if (!string.IsNullOrEmpty(responseBody) && IsJsonContent(context.Response.ContentType))
      {
        try
        {
          var encrypted = Encrypt(responseBody);
          context.Response.ContentLength = null; // 加密后长度变化
          await context.Response.WriteAsync(encrypted);
        }
        catch (Exception ex)
        {
          _logger.LogError(ex, "AES 响应加密失败");
          await context.Response.WriteAsync(responseBody);
        }
      }
      else
      {
        await context.Response.Body.WriteAsync(memoryStream.ToArray());
      }
    }
    finally
    {
      context.Response.Body = originalBodyStream;
    }
  }

  private async Task DecryptRequestAsync(HttpContext context)
  {
    try
    {
      // 解密 Query 中的 params 参数
      var paramsEncrypted = context.Request.Query["params"].FirstOrDefault();
      if (!string.IsNullOrEmpty(paramsEncrypted))
      {
        var decryptedParams = Decrypt(paramsEncrypted);
        if (!string.IsNullOrEmpty(decryptedParams))
        {
          context.Request.QueryString = new QueryString("?" + decryptedParams.TrimStart('?'));
        }
      }

      // 解密 Body 中的 data 参数或整个 body
      if (context.Request.ContentLength > 0 && context.Request.ContentType?.Contains("application/json") == true)
      {
        context.Request.EnableBuffering();
        using var reader = new StreamReader(context.Request.Body, leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        context.Request.Body.Position = 0;

        if (string.IsNullOrWhiteSpace(body))
        {
          return;
        }

        string decryptedBody = null;

        // 尝试解析为 JSON，检查是否有 data 或 params 加密字段
        try
        {
          var json = JObject.Parse(body);
          var dataToken = json["data"];
          var paramsToken = json["params"];

          // 解密 data 字段：解密后的内容作为新的 body（替换整个 body）
          if (dataToken?.Type == JTokenType.String)
          {
            decryptedBody = Decrypt(dataToken.Value<string>());
          }
          // 解密 params 字段
          else if (paramsToken?.Type == JTokenType.String)
          {
            decryptedBody = Decrypt(paramsToken.Value<string>());
          }
        }
        catch
        {
          // 可能整个 body 就是加密的
          try
          {
            decryptedBody = Decrypt(body.Trim().Trim('"'));
          }
          catch
          {
            // 解密失败，可能未加密，保持原样
          }
        }

        if (!string.IsNullOrEmpty(decryptedBody))
        {
          var bytes = Encoding.UTF8.GetBytes(decryptedBody);
          context.Request.Body = new MemoryStream(bytes);
          context.Request.ContentLength = bytes.Length;
        }
      }
    }
    catch (Exception ex)
    {
      _logger.LogWarning(ex, "AES 请求解密失败，使用原始请求");
    }
  }

  private string Decrypt(string encrypted)
  {
    if (string.IsNullOrEmpty(encrypted)) return string.Empty;

    return AesHelper.Decrypt(encrypted, _options.Key, CipherMode.ECB, PaddingMode.PKCS7);
  }

  private string Encrypt(string plainText)
  {
    if (string.IsNullOrEmpty(plainText)) return string.Empty;

    return AesHelper.Encrypt(plainText, _options.Key, CipherMode.ECB, PaddingMode.PKCS7);
  }

  private static bool IsJsonContent(string contentType)
  {
    return !string.IsNullOrEmpty(contentType) && contentType.Contains("application/json");
  }
}
