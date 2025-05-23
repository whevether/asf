﻿using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASF.Internal.Results;

/// <summary>
///   实体结果对象
/// </summary>
/// <typeparam name="T"></typeparam>
public class Result<T> : Result
{
    /// <summary>
    ///   实体结果
    /// </summary>
    public Result()
  {
  }

    /// <summary>
    ///   实体结果
    /// </summary>
    /// <param name="data"></param>
    public Result(T data) : base(BaseResultCodes.Success)
  {
    Data = data;
  }

    /// <summary>
    ///   返回结果对象
    /// </summary>
    /// <param name="data"></param>
    /// <param name="result"></param>
    public Result(T data, ValueTuple<int, string> result) : base(result)
  {
    Data = data;
  }

    /// <summary>
    ///   返回对象
    /// </summary>
    [JsonProperty(PropertyName = "result")]
  public T Data { get; set; }

    /// <summary>
    ///   创建成功的返回消息
    /// </summary>
    /// <returns></returns>
    public static Result<T> ReSuccess(T data)
  {
    return new Result<T>(data);
  }

    /// <summary>
    ///   创建返回信息（返回处理失败）
    /// </summary>
    /// <param name="message">结果消息</param>
    /// <param name="status">结果状态</param>
    /// <returns></returns>
    public new static Result<T> ReFailure(string message, int status)
  {
    var result = new Result<T>();
    result.To(message, status);
    return result;
  }

    /// <summary>
    ///   创建返回信息（返回处理失败）
    /// </summary>
    /// <param name="result">结果消息</param>
    /// <returns></returns>
    public new static Result<T> ReFailure(ValueTuple<int, string> result)
  {
    var res = new Result<T>();
    res.To(result);
    return res;
  }

    /// <summary>
    ///   创建返回信息（返回处理失败）
    /// </summary>
    /// <param name="result">结果</param>
    /// <returns></returns>
    public static Result<T> ReFailure(Result result)
  {
    var re = new Result<T>();
    re.To(result);
    return re;
  }

    /// <summary>
    ///   转换为task
    /// </summary>
    /// <returns></returns>
    public new Task<Result<T>> AsTask()
  {
    return Task.FromResult(this);
  }
}