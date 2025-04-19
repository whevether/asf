using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASF.Internal.Utils;

/// <summary>
///   http请求接口辅助方法
/// </summary>
public class HttpHelper : IHttpHelper
{
  private readonly HttpClient _client;

  /// <summary>
  ///   构造方法
  /// </summary>
  public HttpHelper(IHttpClientFactory httpClientFactory)
  {
    _client = httpClientFactory.CreateClient();
    _client.Timeout = TimeSpan.FromSeconds(60);
    _client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;
  }

  /// <summary>
  ///   put泛型请求
  /// </summary>
  public async Task<T> PutResponse<T>(string url, string putData, Dictionary<string, string> header = null)
    where T : class, new()
  {
    var result = default(T);
    HttpContent httpContent = new StringContent(putData);
    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    httpContent.Headers.ContentType.CharSet = "utf-8";
    if (header != null)
      foreach (var item in header)
        httpContent.Headers.Add(item.Key, item.Value);

    var response = await _client.PutAsync(url, httpContent);

    if (response.IsSuccessStatusCode)
    {
      var t = response.Content.ReadAsStringAsync();
      var s = t.Result;
      result = JsonConvert.DeserializeObject<T>(s);
    }

    return await Task.FromResult(result);
  }

  /// <summary>
  ///   get 泛型请求
  /// </summary>
  public async Task<T> GetResponse<T>(string url, Dictionary<string, string> header = null) where T : class, new()
  {
    var result = default(T);


    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    if (header != null)
      foreach (var item in header)
        _client.DefaultRequestHeaders.Add(item.Key, item.Value);

    var response = await _client.GetAsync(new Uri(url));

    if (response.IsSuccessStatusCode)
    {
      var t = response.Content.ReadAsStringAsync();
      var s = t.Result;
      result = JsonConvert.DeserializeObject<T>(s);
    }

    return await Task.FromResult(result);
  }

  /// <summary>
  ///   post泛型请求
  /// </summary>
  public async Task<T> PostResponse<T>(string url, Dictionary<string, string> dic,
    Dictionary<string, string> header = null) where T : class, new()
  {
    var result = default(T);

    var httpContent = new FormUrlEncodedContent(dic);
    if (header != null)
      foreach (var item in header)
        httpContent.Headers.Add(item.Key, item.Value);
    // httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    // httpContent.Headers.ContentType.CharSet = "utf-8";

    var response = await _client.PostAsync(new Uri(url), httpContent);

    if (response.IsSuccessStatusCode)
    {
      var t = response.Content.ReadAsStringAsync();
      var s = t.Result;
      result = JsonConvert.DeserializeObject<T>(s);
    }

    return await Task.FromResult(result);
  }

  /// <summary>
  ///   post泛型请求 传入json对象
  /// </summary>
  public async Task<T> PostResponse<T>(string url, object content, Dictionary<string, string> header = null)
    where T : class, new()
  {
    var result = default(T);

    var httpContent = new JsonContent(content);
    // httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    // httpContent.Headers.ContentType.CharSet = "utf-8";
    if (header != null)
      foreach (var item in header)
        httpContent.Headers.Add(item.Key, item.Value);

    var response = await _client.PostAsync(new Uri(url), httpContent);

    if (response.IsSuccessStatusCode)
    {
      var t = response.Content.ReadAsStringAsync();
      var s = t.Result;
      result = JsonConvert.DeserializeObject<T>(s);
    }

    return await Task.FromResult(result);
  }

  /// <summary>
  ///   post请求 传入json对象
  /// </summary>
  public async Task<string> PostResponse(string url, object content, Dictionary<string, string> header = null)
  {
    var result = string.Empty;
    var httpContent = new JsonContent(content);
    // httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
    // httpContent.Headers.ContentType.CharSet = "utf-8";
    if (header != null)
      foreach (var item in header)
        httpContent.Headers.Add(item.Key, item.Value);

    var response = await _client.PostAsync(new Uri(url), httpContent);

    if (response.IsSuccessStatusCode)
    {
      var t = response.Content.ReadAsStringAsync();
      result = t.Result;
    }

    return await Task.FromResult(result);
  }
}