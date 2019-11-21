using System;
using System.IO;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Teknologisk.Kursus.Functions
{
    public static class UploadEvent
    {
        [FunctionName("UploadEvent")]
        public static void Run([BlobTrigger("oldfiles/{name}", Connection = "StorageAccountConnection")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            const string storageConnectionString = "https://mainvaultjdk.vault.azure.net/secrets/StorageAccountConnection";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient =
                new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            var blobConnectionString = keyVaultClient.GetSecretAsync(storageConnectionString).GetAwaiter().GetResult().Value;

            var cloudStorageAccount = CloudStorageAccount.Parse(blobConnectionString);
            var cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            var cloudBlobContainer = cloudBlobClient.GetContainerReference("files");
            cloudBlobContainer.CreateIfNotExists();

            log.LogInformation($"Setting permissions to upload");
            cloudBlobContainer.SetPermissions(new BlobContainerPermissions { PublicAccess = BlobContainerPublicAccessType.Blob });

            CloudBlockBlob cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(name);

            log.LogInformation($"uploading {name} to files");
            cloudBlockBlob.UploadFromStream(myBlob);
            log.LogInformation($"Succesfully uploaded blob: {name} to files");
        }
    }
}
