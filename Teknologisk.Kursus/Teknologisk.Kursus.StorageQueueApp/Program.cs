using System;
using System.Collections.Generic;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Auth;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;

namespace Teknologisk.Kursus.StorageQueueApp
{
    class Program
    {

        public class Order
        {
            public int Id { get; set; }
            public double Total { get; set; }
            public string Item { get; set; }
        }

        static void Main(string[] args)
        {
            var connectionString =
                "DefaultEndpointsProtocol=https;AccountName=jdkstorageaccount;AccountKey=0KjykelGGr5bPxwBqm+Dl1GgdrYgwbWJzVc69a7gqL0KeAr+xqatKQuasab6l9geEYZdvLaOeZIyNRcVMHrBMA==;EndpointSuffix=core.windows.net";

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);

            CloudQueueClient cloudQueueClient = cloudStorageAccount.CreateCloudQueueClient();

            var queue = cloudQueueClient.GetQueueReference("orderqueue");

            queue.CreateIfNotExists();

            Console.WriteLine("Add number of message?");
            
            if (int.TryParse(Console.ReadLine(), out int numberOfMessagesToAdd))
            {
                for (int i = 0; i < numberOfMessagesToAdd; i++)
                {
                    var order = new Order()
                    {
                        Id = i,
                        Item = $"order-{i}",
                        Total = new Random().NextDouble()

                    };
                    Console.WriteLine("Adding Item: " + order.Item + " Total: " + order.Total + " Id: " + order.Id);
                    queue.AddMessage(new CloudQueueMessage(JsonConvert.SerializeObject(order, Formatting.Indented)));
                }
            }

           

            Console.WriteLine("Delete number of message?");
            if (int.TryParse(Console.ReadLine(), out int numberOfMessagesToDelete))
            {
                for (int i = 0; i < numberOfMessagesToDelete; i++)
                {
                    var latestMessage = queue.GetMessage();
                    if(latestMessage == null) break;

                    Order latestOrder = JsonConvert.DeserializeObject<Order>(latestMessage.AsString);

                    Console.WriteLine("Deleting Item: " + latestOrder.Item + " Total: " + latestOrder.Total + " Id: " + latestOrder.Id);
                    queue.DeleteMessage(latestMessage);
                }
            }
        }
    }
}
