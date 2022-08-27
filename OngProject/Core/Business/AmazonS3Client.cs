using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using OngProject.Core.Interfaces;
using System;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class AmazonS3Client : IAmazonS3Client
    {
        private readonly IAmazonS3 _s3Client;

        public AmazonS3Client(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<GetObjectResponse> GetObject(string bucketName, string objectName)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {bucketName} does not exist.");

            return await _s3Client.GetObjectAsync(bucketName, objectName);
        }

        public async Task<string> UploadObject(string bucketName, IFormFile file)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {bucketName} does not exist.");

            var uniqueObjectName = Guid.NewGuid().ToString();

            var request = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = uniqueObjectName,
                InputStream = file.OpenReadStream(),
                //  ↓↓ Pone los archivos subidos al bucket con acceso publico
                CannedACL = new S3CannedACL("public-read")
            };

            request.Metadata.Add("Content-Type", file.ContentType);
            await _s3Client.PutObjectAsync(request);
            return uniqueObjectName;
        }

        public async Task DeleteObject(string bucketName, string objectName)
        {
            var existing = await _s3Client.DoesS3BucketExistAsync(bucketName);

            if (!existing)
                throw new System.Exception($"Bucket {bucketName} does not exist.");

            await _s3Client.DeleteObjectAsync(bucketName, objectName);
        }

    }
}
