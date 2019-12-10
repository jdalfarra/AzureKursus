using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Teknologisk.Kursus.QueueFunctionTrigger
{

    public class Order
    {
        public int Id { get; set; }
        public double Total { get; set; }
        public string Item { get; set; }
    }

    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("orderqueue", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");

            var newOrder = JsonConvert.DeserializeObject<Order>(myQueueItem);

            log.LogInformation($"New order added: Id: {newOrder.Id} Item: {newOrder.Item} Total: {newOrder.Total}");
        }
    }
}
