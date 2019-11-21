using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System.Collections.Generic;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Teknologiks.Kursus.Website.Models;

namespace Teknologiks.Kursus.Website.Controllers
{
    public class BlobController : Controller
    {
        public IActionResult Index()
        {
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

            var blobs = cloudBlobContainer.ListBlobs();

            var containerBlobs = new List<Blob>();

            foreach(var blob in blobs)
            {
                if(blob is CloudBlockBlob)
                {
                    var cloudBlockBlob = (CloudBlockBlob)blob;

                    containerBlobs.Add(new Blob()
                    {
                        Name = cloudBlockBlob.Name,
                        Size = cloudBlockBlob.Properties.Length.ToString() + " b",
                        Url = cloudBlockBlob.Uri.ToString()
                    });
                }
            }


            return View(containerBlobs);
        }
    }
}