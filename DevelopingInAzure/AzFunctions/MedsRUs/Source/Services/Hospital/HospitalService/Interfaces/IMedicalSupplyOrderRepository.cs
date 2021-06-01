using HospitalService.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalService.Interfaces
{

    public interface IMedicalSupplyOrderRepository
    {
        Task<bool> ApproveMedicalSupplyOrder(string connectionString, MedicineOrderApproval medicineOrderApproval);

        Task<bool> ModifyOrderWithPharmacyUpdates(string connectionString, MedicineOrderPharmacyApproval medicineOrderPharmacyApproval);

        Task<bool> PlaceMedicalSupplyOrder(string connectionString, MedicineOrder medicineOrder);

        Task<MedicineOrder> RetrieveMedicalSupplyOrder(string connectionString, Guid id);

        Task<IEnumerable<MedicineOrder>> MedicalSupplyOrdersForApproval(string connectionString);
    }

}