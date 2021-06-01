using HospitalService.Data;
using HospitalService.Interfaces;
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
        private readonly IMedicalSupplyOrderRepository _medicalSupplyOrderRepository;

        public MedicalSupplyOrderRequest(IConnectionStrings connectionStrings, IMedicalSupplyOrderRepository medicalSupplyOrderRepository)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            _medicalSupplyOrderRepository = medicalSupplyOrderRepository ?? throw new ArgumentNullException(nameof(medicalSupplyOrderRepository));
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

            _ = await _medicalSupplyOrderRepository
                        .PlaceMedicalSupplyOrder(_connectionStrings.SqlServerConnectionString, medicineOrder)
                        .ConfigureAwait(false);

            if (medicineOrder.OrderStatus == "Approved")
            {
                await medicialSuppyOrders.AddAsync(medicineOrder);
            }

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new OkObjectResult(medicineOrder);
        }

    }

}
