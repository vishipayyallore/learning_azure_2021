using HospitalService.Data;
using HospitalService.Interfaces;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;

namespace HospitalService
{
    public class MedicalSupplyOrderPharmacyApproval
    {

        private readonly IConnectionStrings _connectionStrings;
        private readonly IMedicalSupplyOrderRepository _medicalSupplyOrderRepository;

        public MedicalSupplyOrderPharmacyApproval(IConnectionStrings connectionStrings, IMedicalSupplyOrderRepository medicalSupplyOrderRepository)
        {
            _connectionStrings = connectionStrings ?? throw new ArgumentNullException(nameof(connectionStrings));

            _medicalSupplyOrderRepository = medicalSupplyOrderRepository ?? throw new ArgumentNullException(nameof(medicalSupplyOrderRepository));
        }

        [FunctionName("MedicalSupplyOrderPharmacyApproval")]
        public async void Run([ServiceBusTrigger("sbq-medicialsupplyorders-out", Connection = "ServiceBusConnection")] string medicineOrderQueueItem
            , ILogger log)
        {
            log.LogInformation($"Received Medicine Order Pharmacy Updates from ServiceBus queue : {medicineOrderQueueItem}");

            MedicineOrderPharmacyApproval medicineOrderPharmacyApproval = JsonConvert.DeserializeObject<MedicineOrderPharmacyApproval>(medicineOrderQueueItem);

            _ = await _medicalSupplyOrderRepository
                        .ModifyOrderWithPharmacyUpdates(_connectionStrings.SqlServerConnectionString, medicineOrderPharmacyApproval)
                        .ConfigureAwait(false);

            log.LogInformation($"Received Medicine Order Pharmacy Updated Sent to SQL Server: {medicineOrderPharmacyApproval}");
        }

    }
}
