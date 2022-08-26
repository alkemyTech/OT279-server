using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IAmazonS3Client
    {
        // Crea un espacio en disco en los servidores de Amazon S3.
        // Un Bucket puede considerarse como una carpeta remota.
        Task CreateBucket(string bucketName);

        // Almacena un archivo en un Bucket(Carpeta remota)
        // Devuelve el nuevo nombre del archivo asignado automáticamente.
        // Dicho nombre puede ser usado para ser guardado en la base de datos local.
        Task<string> UploadObject(string bucketName, IFormFile file);

        Task<GetObjectResponse> GetObject(string bucketName, string objectName);

        Task DeleteObject(string bucketName, string objectName);
    }
}
