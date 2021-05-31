using HospitalService.Data;
using System;

namespace HospitalService.Interfaces
{

    public interface IMedicalSupplyOrderRepository
    {
        bool ApproveMedicalSupplyOrder(string connectionString, MedicineOrderApproval medicineOrderApproval);

        bool ModifyOrderWithPharmacyUpdates(string connectionString, MedicineOrderPharmacyApproval medicineOrderPharmacyApproval);

        bool PlaceMedicalSupplyOrder(string connectionString, MedicineOrder medicineOrder);

        MedicineOrder RetrieveMedicalSupplyOrder(string connectionString, Guid id);
    }

}