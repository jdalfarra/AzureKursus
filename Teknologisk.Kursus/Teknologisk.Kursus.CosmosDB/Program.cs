using System;
using Microsoft.Azure.Cosmos.Table;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;

namespace Teknologisk.Kursus.CosmosDB
{
    class Program
    {
        static void Main(string[] args)
        {
            //Connect to DB

            const string storageConnectionString = "https://mainvaultjdk.vault.azure.net/secrets/CosmosDBConnectionString";
            var azureServiceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient =
                new KeyVaultClient(
                    new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback));

            //Replace with new connectionstring from cosmos db
            var tableConnectionString = keyVaultClient.GetSecretAsync(storageConnectionString).GetAwaiter().GetResult().Value;

            Console.WriteLine("Connection to bd");

            var cloudStorageAccount = CloudStorageAccount.Parse(tableConnectionString);
            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable customersTable = cloudTableClient.GetTableReference("customers");
            customersTable.CreateIfNotExists();

            Customer customer = new Customer("Aarhus", "2")
            {
                PartitionKey = "Farmers",
                Email = "test@test.dk",
                FirstName = "John",
                LastName = "Doe",
                Category = "test",
            };

            Console.WriteLine("Adding customer: " + customer.FirstName);

            var tableOperation = TableOperation.Insert(customer);
            customersTable.Execute(tableOperation);

            Console.WriteLine("Customer added");
        }
    }
}
