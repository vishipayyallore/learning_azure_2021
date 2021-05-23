using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace OrderService
{
    public static class SendOrderToPharmacy
    {
        [FunctionName("SendOrderToPharmacy")]
        public static void Run([ServiceBusTrigger("medicialsuppyorders", Connection = "ServiceBusConnection")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
