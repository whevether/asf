using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASF.Internal.Utils;

/// <summary>
///   http请求接口辅助方法
/// </summary>
public interface IHttpHelper
{
  /// <summary>
  ///   put泛型请求
  /// </summary>
  Task<T> PutResponse<T>(string url, string putData, Dictionary<string, string> header = null) where T : class, new();

  /// <summary>
  ///   get 泛型请求
  /// </summary>
  Task<T> GetResponse<T>(string url, Dictionary<string, string> header = null) where T : class, new();

  /// <summary>
  ///   post泛型请求
  /// </summary>
  Task<T> PostResponse<T>(string url, Dictionary<string, string> dic, Dictionary<string, string> header = null)
    where T : class, new();

  /// <summary>
  ///   post泛型请求 传入json对象
  /// </summary>
  Task<T> PostResponse<T>(string url, object content, Dictionary<string, string> header = null)
    where T : class, new();

  /// <summary>
  ///   post泛型请求 传入json对象
  /// </summary>
  Task<string> PostResponse(string url, object content, Dictionary<string, string> header = null);
}