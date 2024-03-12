using System.IO;
using System.Threading.Tasks;
using System.Web;
using ASF.DependencyInjection;
using ASF.Domain.Values;
using ASF.Internal;
using Microsoft.Extensions.Options;
using Minio;
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
    public async Task<object> UploadFile(string preFix, string fileName, Stream st, string fileType,long fileLength)
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
        FileValue fileValue = new FileValue()
        {
            Url = HttpUtility.UrlEncode($"https://{_minio.Endpoint}/{preFix}/{newFileName}")
        };
        return await Task.FromResult<object>(fileValue);
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
            var policyReadWrite = "{\"Version\":\"2012-10-17\",\"Statement\":[{\"Effect\":\"Allow\",\"Principal\":{\"AWS\":[\"*\"]},\"Action\":[\"s3:GetBucketLocation\",\"s3:ListBucketMultipartUploads\"],\"Resource\":[\"arn:aws:s3:::BUCKETNAME\"]},{\"Effect\":\"Allow\",\"Principal\":{\"AWS\":[\"*\"]},\"Action\":[\"s3:ListBucket\"],\"Resource\":[\"arn:aws:s3:::BUCKETNAME\"],\"Condition\":{\"StringEquals\":{\"s3:prefix\":[\"BUCKETPREFIX\"]}}},{\"Effect\":\"Allow\",\"Principal\":{\"AWS\":[\"*\"]},\"Action\":[\"s3:PutObject\",\"s3:AbortMultipartUpload\",\"s3:DeleteObject\",\"s3:GetObject\",\"s3:ListMultipartUploadParts\"],\"Resource\":[\"arn:aws:s3:::BUCKETNAME/BUCKETPREFIX*\"]}]}";
            var policy = new SetPolicyArgs()
                .WithBucket(bucketName)
                .WithPolicy(policyReadWrite);
            await _client.SetPolicyAsync(policy);
        }
    }
}