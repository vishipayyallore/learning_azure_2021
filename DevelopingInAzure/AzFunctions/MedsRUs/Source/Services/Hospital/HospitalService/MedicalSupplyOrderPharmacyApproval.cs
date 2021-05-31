using HospitalService.Data;
using HospitalService.Interfaces;
using HospitalService.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace HospitalService
{
    public class MedicalSupplyOrderPharmacyApproval
    {

        private readonly IConnectionStrings _connectionStrings;

        public MedicalSupplyOrderPharmacyApproval(IConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));
        }

        [FunctionName("MedicalSupplyOrderPharmacyApproval")]
        public void Run([ServiceBusTrigger("sbq-medicialsupplyorders-out", Connection = "ServiceBusConnection")] string medicineOrderQueueItem
            , ILogger log)
        {
            log.LogInformation($"Received Medicine Order Pharmacy Updates from ServiceBus queue : {medicineOrderQueueItem}");

            MedicineOrderPharmacyApproval medicineOrderPharmacyApproval = JsonConvert.DeserializeObject<MedicineOrderPharmacyApproval>(medicineOrderQueueItem);

            MedicalSupplyOrderRepository.ModifyOrderWithPharmacyUpdates(_connectionStrings.SqlServerConnectionString, medicineOrderPharmacyApproval);

            log.LogInformation($"Received Medicine Order Pharmacy Updated Sent to SQL Server: {medicineOrderPharmacyApproval}");
        }

    }
}
