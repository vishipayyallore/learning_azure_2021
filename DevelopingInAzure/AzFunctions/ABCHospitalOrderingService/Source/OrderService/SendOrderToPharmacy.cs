using MedsRUs.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace OrderService
{

    public static class SendOrderToPharmacy
    {

        [FunctionName("SendOrderToPharmacy")]
        public static async void Run([ServiceBusTrigger("medicialsupplyorders", Connection = "ServiceBusConnection")] string medicineOrderQueueItem,
            [CosmosDB(databaseName: "MedsRUsDataStore", collectionName: "MedOrders", ConnectionStringSetting = "CosmosDBConnection")]
            IAsyncCollector<MedicineOrder> medicineOrderAsyncCollector,
            ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {medicineOrderQueueItem}");

            MedicineOrder medicineOrder = JsonConvert.DeserializeObject<MedicineOrder>(medicineOrderQueueItem);

            await medicineOrderAsyncCollector.AddAsync(medicineOrder);
        }

    }

}
