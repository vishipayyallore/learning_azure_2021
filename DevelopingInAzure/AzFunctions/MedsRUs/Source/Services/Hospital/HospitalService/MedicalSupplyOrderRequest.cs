using HospitalService.Data;
using HospitalService.Interfaces;
using HospitalService.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HospitalService
{
    public class MedicalSupplyOrderRequest
    {

        private readonly IConnectionStrings _connectionStrings;

        public MedicalSupplyOrderRequest(IConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [FunctionName("RequestMedicalSupplyOrder")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("sbq-medicialsupplyorders-in", Connection = "ServiceBusConnection",
            EntityType = EntityType.Queue)] IAsyncCollector<MedicineOrder> medicialSuppyOrders,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for medical order.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MedicineOrder medicineOrder = JsonConvert.DeserializeObject<MedicineOrder>(requestBody);

            MedicalSupplyOrderRepository.PlaceMedicalSupplyOrder(_connectionStrings.SqlServerConnectionString, medicineOrder);

            if (medicineOrder.OrderStatus == "Approved")
            {
                await medicialSuppyOrders.AddAsync(medicineOrder);
            }

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new OkObjectResult(medicineOrder);
        }

    }

}
