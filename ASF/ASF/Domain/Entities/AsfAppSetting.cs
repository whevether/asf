using System;

namespace ASF.Domain.Entities;

/// <summary>
///   app设置表
/// </summary>
public class AsfAppSetting : Entity<long>
{
    /// <summary>
    ///   包名
    /// </summary>
    public string WrapName { get; set; }

    /// <summary>
    ///   系统类型 0 安卓 1 ios
    /// </summary>
    public int? OsType { get; set; }

    /// <summary>
    ///   版本号
    /// </summary>
    public string VersionNo { get; set; }

    /// <summary>
    ///   版本名称
    /// </summary>
    public string VersionName { get; set; }

    /// <summary>
    ///   更新内容
    /// </summary>
    public string Content { get; set; }

    /// <summary>
    ///   下载地址
    /// </summary>
    public string DownUrl { get; set; }

    /// <summary>
    ///   包体积
    /// </summary>
    public decimal? WrapSize { get; set; }

    /// <summary>
    ///   更新开启状态， 0不开启 1开启
    /// </summary>
    public int? UpdateStatus { get; set; }

    /// <summary>
    ///   更新类型 0 强制升级 1 强提示升级 2 弱提示升级
    /// </summary>
    public int? UpdateType { get; set; }

    /// <summary>
    ///   创建时间
    /// </summary>
    public DateTime CreateTime { get; set; }

    /// <summary>
    ///   修改时间
    /// </summary>
    public DateTime UpdateTime { get; set; }
}