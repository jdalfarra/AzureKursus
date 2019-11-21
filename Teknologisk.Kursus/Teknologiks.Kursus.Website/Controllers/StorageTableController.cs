using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Teknologiks.Kursus.Website.Models;

namespace Teknologiks.Kursus.Website.Controllers
{
    public class StorageTableController : Controller
    {
        public IActionResult Index()
        {
            const string storageConnectionString = "https://mainvaultjdk.vault.azure.net/secrets/StorageAccountConnection";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient =
                new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            var tableConnectionString = keyVaultClient.GetSecretAsync(storageConnectionString).GetAwaiter().GetResult().Value;

            var cloudStorageAccount = CloudStorageAccount.Parse(tableConnectionString);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable customersTable = cloudTableClient.GetTableReference("customers");
            customersTable.CreateIfNotExists();

            TableQuery<Customer> query = new TableQuery<Customer>();

            var customers = customersTable.ExecuteQuery(query).ToList();

            return View(customers);
        }
    }
}