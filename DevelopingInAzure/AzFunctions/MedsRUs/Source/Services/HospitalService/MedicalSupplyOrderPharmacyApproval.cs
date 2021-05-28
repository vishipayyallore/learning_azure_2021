using HospitalService.Data;
using HospitalService.Repositories;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HospitalService
{
    public static class MedicalSupplyOrderPharmacyApproval
    {

        [FunctionName("MedicalSupplyOrderPharmacyApproval")]
        public static void Run([ServiceBusTrigger("sbq-medicialsupplyorders-out", Connection = "ServiceBusConnection")] string medicineOrderQueueItem
            , ILogger log)
        {
            log.LogInformation($"Received Medicine Order Pharmacy Updates from ServiceBus queue : {medicineOrderQueueItem}");

            // TODO: Tech Debt (It should be part of Dependency Injection)
            SettingsData settingsData = new SettingsData();

            MedicineOrderPharmacyApproval medicineOrderPharmacyApproval = JsonConvert.DeserializeObject<MedicineOrderPharmacyApproval>(medicineOrderQueueItem);

            MedicalSupplyOrderRepository.ModifyOrderWithPharmacyUpdates(settingsData.SqlServerConnectionString, medicineOrderPharmacyApproval);

            log.LogInformation($"Received Medicine Order Pharmacy Updated Sent to SQL Server: {medicineOrderPharmacyApproval}");
        }

    }
}
