using System;

namespace PharmacyService.Data
{

    public class MedicineOrderApproval
    {
        public string LotNumber { get; set; } = "";

        public string PhramacyOrderStatus { get; set; } = "Pending";

        public string PhramacyAdditionalComments { get; set; } = "Please approve";
    }

}
