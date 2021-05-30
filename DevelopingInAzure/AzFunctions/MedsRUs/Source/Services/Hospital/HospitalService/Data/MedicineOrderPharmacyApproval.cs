using System;

namespace HospitalService.Data
{

    public class MedicineOrderPharmacyApproval
    {
        public Guid Id { get; set; }

        public DateTime PharmacyTimeofApproval { get; set; } = DateTime.Now;

        public string PharmacyOrderStatus { get; set; }

        public string PharmacyAdditionalComments { get; set; }
    }

}
