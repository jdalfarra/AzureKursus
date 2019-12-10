using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Teknologisk.Kursus.ServiceBusQueue
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionStringQueue =
                "Endpoint=sb://jdk-servicebus.servicebus.windows.net/;SharedAccessKeyName=sender;SharedAccessKey=RtvvrYUw5mMgW55z3WxLk0Y2s4ifKtws6g9Nzsbbr9g=;EntityPath=jdk-queue";

            ServiceBusConnectionStringBuilder serviceBusConnection = new ServiceBusConnectionStringBuilder(connectionStringQueue);

            QueueClient queueClient = new QueueClient(serviceBusConnection);
            Console.WriteLine("Add number of message to add to queue?");

            if (int.TryParse(Console.ReadLine(), out int numberOfMessagesToAddQueue))
            {
                for (int i = 0; i < numberOfMessagesToAddQueue; i++)
                {
                    Message msg = new Message();
                    msg.Body = Encoding.UTF8.GetBytes("Test msg: " + DateTime.Now.ToLongDateString());
                    await queueClient.SendAsync(msg);
                }
            }

            var connectionStringTopic =
                "Endpoint=sb://jdk-servicebus.servicebus.windows.net/;SharedAccessKeyName=sender;SharedAccessKey=ObRpvUKSFPYjcHzQEFtI9pfoftP99NZS6QDzSWlZt7Y=;EntityPath=toptictest";

            ServiceBusConnectionStringBuilder topicConnectionStringBuilder = new ServiceBusConnectionStringBuilder(connectionStringTopic);

            TopicClient topicClient = new TopicClient(topicConnectionStringBuilder);
            Console.WriteLine("Add number of message to add to topic?");

            if (int.TryParse(Console.ReadLine(), out int numberOfMessagesToAddTopic))
            {
                for (int i = 0; i < numberOfMessagesToAddTopic; i++)
                {
                    Message msg = new Message();
                    msg.Body = Encoding.UTF8.GetBytes("Test msg: " + DateTime.Now.ToLongDateString());
                    await topicClient.SendAsync(msg);
                }
            }
        }
    }
}
