using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PharmacyService.Data;
using System;
using System.IO;
using System.Threading.Tasks;

namespace PharmacyService
{
    public class UpdatePharmacyOrder
    {
        [FunctionName("UpdatePharmacyOrder")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post",
            Route = "UpdatePharmacyOrder/{partitionKey}/{id}")] HttpRequest req,
            [CosmosDB(databaseName: "MedsRUsDataStore", collectionName: "MedOrders", ConnectionStringSetting = "CosmosDBConnection"
            , Id = "{id}", PartitionKey = "{partitionKey}")] MedicineOrder medicineOrder,
            [ServiceBus("sbq-medicialsupplyorders-out", Connection = "ServiceBusConnection",
            EntityType = EntityType.Queue)] IAsyncCollector<MedicineOrder> medicialSuppyOrders,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for updating pharmacy medical order.");

            log.LogInformation($"Medicine Order from Cosmos Db: {medicineOrder}");

            if (medicineOrder == null)
            {
                return new NotFoundResult();
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MedicineOrderApproval medicineOrderApproval = JsonConvert.DeserializeObject<MedicineOrderApproval>(requestBody);

            medicineOrder.LotNumber = medicineOrderApproval.LotNumber;
            medicineOrder.PharmacyTimeofApproval = DateTime.Now;
            medicineOrder.PharmacyOrderStatus = medicineOrderApproval.PharmacyOrderStatus;
            medicineOrder.PharmacyAdditionalComments = medicineOrderApproval.PharmacyAdditionalComments;

            await medicialSuppyOrders.AddAsync(medicineOrder);

            return new OkObjectResult(medicineOrder);
        }
    }
}
