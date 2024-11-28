using System.IO;
using System.Threading.Tasks;
using ASF.DependencyInjection;
using ASF.Domain.Values;
using ASF.Internal;
using Microsoft.Extensions.Options;
using Minio;
using Minio.DataModel;
using Minio.DataModel.Args;

namespace ASF.Domain.Services;
/// <summary>
/// 上传服务
/// </summary>
public class UploadService
{
    private readonly IMinioClient _client;
    private readonly MinioOp _minio;
    private readonly IIdGenerator _idGenerator;
    /// <summary>
    /// 
    /// </summary>
    public UploadService(IMinioClient client,IIdGenerator idGenerator,IOptions<MinioOp> minio)
    {
        _client = client;
        _minio = minio?.Value;
        _idGenerator = idGenerator;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="preFix"></param>
    /// <param name="fileName"></param>
    /// <param name="st"></param>
    /// <param name="fileType"></param>
    /// <param name="fileLength"></param>
    /// <returns></returns>
    public async Task<string> UploadFile(string preFix, string fileName, Stream st, string fileType,long fileLength)
    {
        await CreateBucket(preFix);
        string newFileName = $"{_idGenerator.GenId()}{preFix}{fileName.Trim()}";
        var args = new PutObjectArgs()
            .WithBucket(preFix)
            .WithObject(newFileName)
            .WithStreamData(st)
            .WithObjectSize(fileLength)
            .WithContentType(fileType);
        await _client.PutObjectAsync(args);
        return await Task.FromResult<string>($"{_minio.Endpoint}{_minio.MinioUrl}/{preFix}/{newFileName}");
    }

    /// <summary>
    /// 创建桶
    /// </summary>
    /// <param name="bucketName"></param>
    private async Task CreateBucket(string bucketName)
    {
        var existBucket = new BucketExistsArgs();
        existBucket.WithBucket(bucketName);
        var found = await _client.BucketExistsAsync(existBucket);
        if (!found)
        {
            var bucket = new MakeBucketArgs()
                .WithBucket(bucketName)
                .WithLocation("us-east-1");
            
            await _client.MakeBucketAsync(bucket);
            string policyJson =  "{\"Version\":\"2012-10-17\",\"Statement\":[{\"Effect\":\"Allow\",\"Principal\":{\"AWS\":[\"*\"]},\"Action\":[\"s3:GetBucketLocation\",\"s3:ListBucket\",\"s3:ListBucketMultipartUploads\"],\"Resource\":[\"arn:aws:s3:::image\"]},{\"Effect\":\"Allow\",\"Principal\":{\"AWS\":[\"*\"]},\"Action\":[\"s3:AbortMultipartUpload\",\"s3:DeleteObject\",\"s3:GetObject\",\"s3:ListMultipartUploadParts\",\"s3:PutObject\"],\"Resource\":[\"arn:aws:s3:::*/*\"]}]}";
            var policy = new SetPolicyArgs()
                .WithBucket(bucketName)
                .WithPolicy(policyJson);
            await _client.SetPolicyAsync(policy);
        }
    }
}