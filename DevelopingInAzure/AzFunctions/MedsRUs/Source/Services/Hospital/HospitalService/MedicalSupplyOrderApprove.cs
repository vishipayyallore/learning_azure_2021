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
    public class MedicalSupplyOrderApprove
    {

        private readonly IConnectionStrings _connectionStrings;
        private readonly IMedicalSupplyOrderRepository _medicalSupplyOrderRepository;

        public MedicalSupplyOrderApprove(IConnectionStrings connectionStrings, IMedicalSupplyOrderRepository medicalSupplyOrderRepository)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            _medicalSupplyOrderRepository = medicalSupplyOrderRepository ?? throw new ArgumentNullException(nameof(medicalSupplyOrderRepository));
        }

        [FunctionName("ApproveMedicalSupplyOrder")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("sbq-medicialsupplyorders-in", Connection = "ServiceBusConnection",
            EntityType = EntityType.Queue)] IAsyncCollector<MedicineOrder> medicialSuppyOrders,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for medical order.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MedicineOrderApproval medicineOrderApproval = JsonConvert.DeserializeObject<MedicineOrderApproval>(requestBody);

            MedicineOrder medicineOrder = _medicalSupplyOrderRepository
                .RetrieveMedicalSupplyOrder(_connectionStrings.SqlServerConnectionString, medicineOrderApproval.Id);

            if (medicineOrder == null)
            {
                return new NotFoundResult();
            }

            medicineOrder.TimeofApproval = medicineOrderApproval.TimeofApproval = DateTime.Now;
            medicineOrder.OrderStatus = medicineOrderApproval.OrderStatus;
            medicineOrder.AdditionalComments = medicineOrderApproval.AdditionalComments;

            _ = _medicalSupplyOrderRepository.ApproveMedicalSupplyOrder(_connectionStrings.SqlServerConnectionString, medicineOrderApproval);

            if (medicineOrderApproval.OrderStatus == "Approved")
            {
                await medicialSuppyOrders.AddAsync(medicineOrder);
            }

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new NoContentResult();
        }

    }

}
