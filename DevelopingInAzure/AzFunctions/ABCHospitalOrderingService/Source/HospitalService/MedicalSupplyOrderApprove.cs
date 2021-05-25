using HospitalService.Data;
using MedsRUs.Data;
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
    public static class MedicalSupplyOrderApprove
    {

        [FunctionName("ApproveMedicalSupplyOrder")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("sbq-medicialsupplyorders-in", Connection = "ServiceBusConnection",
            EntityType = EntityType.Queue)] IAsyncCollector<MedicineOrder> medicialSuppyOrders,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for medical order.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MedicineOrderApproval medicineOrderApproval = JsonConvert.DeserializeObject<MedicineOrderApproval>(requestBody);

            SettingsData settingsData = new SettingsData();

            MedicineOrder medicineOrder = MedicalSupplyOrderRepository.RetrieveMedicalSupplyOrder(settingsData.SqlServerConnectionString, medicineOrderApproval.Id);

            if (medicineOrder == null)
            {
                return new NotFoundResult();
            }

            medicineOrder.TimeofApproval = medicineOrderApproval.TimeofApproval = DateTime.Now;
            medicineOrder.OrderStatus = medicineOrderApproval.OrderStatus;
            medicineOrder.AdditionalComments = medicineOrderApproval.AdditionalComments;

            MedicalSupplyOrderRepository.ApproveMedicalSupplyOrder(settingsData.SqlServerConnectionString, medicineOrderApproval);

            if (medicineOrderApproval.OrderStatus == "Approved")
            {
                await medicialSuppyOrders.AddAsync(medicineOrder);
            }

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new NoContentResult();
        }

    }

}
