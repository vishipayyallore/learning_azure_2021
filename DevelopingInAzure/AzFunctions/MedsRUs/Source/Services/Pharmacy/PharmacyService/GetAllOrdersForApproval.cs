using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using PharmacyService.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PharmacyService
{

    public class GetAllOrdersForApproval
    {

        [FunctionName("GetAllOrdersForApproval")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            [CosmosDB(databaseName: "MedsRUsDataStore", collectionName: "MedOrders", ConnectionStringSetting = "CosmosDBConnection"
            ,SqlQuery = "SELECT * FROM c where c.PharmacyOrderStatus != \"In Stock\"")]
            IEnumerable<MedicineOrder> medicineOrdersList,
            ILogger log)
        {

            log.LogInformation("C# HTTP trigger request received for GetAllOrdersForApproval.");

            log.LogInformation("C# HTTP trigger Sending output for GetAllOrdersForApproval.");

            return new OkObjectResult(await Task.FromResult(medicineOrdersList));
        }

    }

}
