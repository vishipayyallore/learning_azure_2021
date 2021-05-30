using System;

namespace PharmacyService.Data
{

    public class MedicineOrderApproval
    {
        public string LotNumber { get; set; } = "";

        public string PharmacyOrderStatus { get; set; } = "Pending";

        public string PharmacyAdditionalComments { get; set; } = "Please approve";
    }

}
