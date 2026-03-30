using System.ComponentModel;

namespace ASF.Domain.Values;

/// <summary>
///   上传类型
/// </summary>
public enum UploadType
{
    /// <summary>
    /// </summary>
    [Description("头像")] avatar = 0,

    /// <summary>
    /// </summary>
    [Description("app包")] apk = 1,

    /// <summary>
    /// </summary>
    [Description("图片")] image = 2,

    /// <summary>
    /// </summary>
    [Description("文件")] file = 3
}