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

    public class MedicalSupplyOrdersForApproval
    {

        private readonly IConnectionStrings _connectionStrings;
        private readonly IMedicalSupplyOrderRepository _medicalSupplyOrderRepository;

        public MedicalSupplyOrdersForApproval(IConnectionStrings connectionStrings, IMedicalSupplyOrderRepository medicalSupplyOrderRepository)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            _medicalSupplyOrderRepository = medicalSupplyOrderRepository ?? throw new ArgumentNullException(nameof(medicalSupplyOrderRepository));
        }

        [FunctionName("MedicalSupplyOrdersForApproval")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for medical order.");

            var medicineOrdersList = await _medicalSupplyOrderRepository
                        .MedicalSupplyOrdersForApproval(_connectionStrings.SqlServerConnectionString)
                        .ConfigureAwait(false);

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new OkObjectResult(medicineOrdersList);
        }

    }

}
