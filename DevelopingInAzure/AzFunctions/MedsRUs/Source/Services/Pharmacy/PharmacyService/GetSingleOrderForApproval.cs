using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PharmacyService.Data;
using System.Threading.Tasks;

namespace PharmacyService
{
    public class GetSingleOrderForApproval
    {
        [FunctionName("GetSingleOrderForApproval")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetSingleOrderForApproval/{partitionKey}/{id}")]
            HttpRequest req,
            [CosmosDB(databaseName: "MedsRUsDataStore", collectionName: "MedOrders", ConnectionStringSetting = "CosmosDBConnection"
            , Id = "{id}", PartitionKey = "{partitionKey}")] MedicineOrder medicineOrder,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for Single pharmacy medical order.");

            log.LogInformation($"Medicine Order from Cosmos Db: {medicineOrder}");

            if (medicineOrder == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(await Task.FromResult(medicineOrder));
        }
    }
}
