using HospitalService.Data;
using HospitalService.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HospitalService
{
    public class MedicalSupplyOrderById
    {

        private readonly IConnectionStrings _connectionStrings;
        private readonly IMedicalSupplyOrderRepository _medicalSupplyOrderRepository;

        public MedicalSupplyOrderById(IConnectionStrings connectionStrings, IMedicalSupplyOrderRepository medicalSupplyOrderRepository)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            _medicalSupplyOrderRepository = medicalSupplyOrderRepository ?? throw new ArgumentNullException(nameof(medicalSupplyOrderRepository));
        }

        [FunctionName("GetMedicalSupplyOrderById")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "GetMedicalSupplyOrderById/{id}")] HttpRequest req,
            Guid id,
            ILogger log)
        {
            log.LogInformation($"Request received for Get medical order By Id {id}.");

            MedicineOrder medicineOrder = await _medicalSupplyOrderRepository
                .RetrieveMedicalSupplyOrder(_connectionStrings.SqlServerConnectionString, id)
                .ConfigureAwait(false);

            if (medicineOrder == null)
            {
                return new NotFoundResult();
            }

            log.LogInformation($"Sending medical order For Id {id}");

            return new OkObjectResult(medicineOrder);
        }
    }
}
