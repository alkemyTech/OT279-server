using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OngProject.Core.Business
{
    public class AmazonS3Client : IAmazonS3Client
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IConfiguration _configuration;
        private string _bucketName;

        public AmazonS3Client(IAmazonS3 s3Client, IConfiguration configuration)
        {
            _s3Client = s3Client;
            _configuration = configuration;
            _bucketName = _configuration.GetSection("AWS:BucketName").Value;
        }

        public async Task<GetObjectResponse> GetObject(string objectName)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(_bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {_bucketName} does not exist.");

            return await _s3Client.GetObjectAsync(_bucketName, objectName);
        }

        public async Task<string> UploadObject(IFormFile file)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(_bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {_bucketName} does not exist.");

            var uniqueObjectName = Guid.NewGuid().ToString();

            var request = new PutObjectRequest()
            {
                BucketName = _bucketName,
                Key = uniqueObjectName,
                InputStream = file.OpenReadStream(),
                //  ↓↓ Pone los archivos subidos al bucket con acceso publico
                CannedACL = new S3CannedACL("public-read")
            };

            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            return $"https://{_bucketName}.s3.amazonaws.com/{uniqueObjectName}";
        }

        public async Task DeleteObject(string objectName)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(_bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {_bucketName} does not exist.");

            //var arr = url.Split('/');
            //var objectName = arr[arr.Length - 1];

            await _s3Client.DeleteObjectAsync(_bucketName, objectName);
        }

    }
}
