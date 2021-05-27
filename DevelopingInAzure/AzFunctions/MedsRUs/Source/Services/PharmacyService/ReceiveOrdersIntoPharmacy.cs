using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PharmacyService.Data;

namespace PharmacyService
{
    public static class ReceiveOrdersIntoPharmacy
    {
        [FunctionName("ReceiveOrdersIntoPharmacy")]
        public static async void Run([ServiceBusTrigger("sbq-medicialsupplyorders-in", Connection = "ServiceBusConnection")] string medicineOrderQueueItem,
            [CosmosDB(databaseName: "MedsRUsDataStore", collectionName: "MedOrders", ConnectionStringSetting = "CosmosDBConnection")]
            IAsyncCollector<MedicineOrder> medicineOrderAsyncCollector,
            ILogger log)
        {
            log.LogInformation($"Received Medicine Order from ServiceBus queue : {medicineOrderQueueItem}");

            MedicineOrder medicineOrder = JsonConvert.DeserializeObject<MedicineOrder>(medicineOrderQueueItem);

            await medicineOrderAsyncCollector.AddAsync(medicineOrder);

            log.LogInformation($"Medicine Order Sent to Cosmos Db: {medicineOrder}");
        }

    }

}
