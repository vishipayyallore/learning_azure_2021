using System;

namespace HospitalService.Data
{

    public class MedicineOrderApproval
    {
        public Guid Id { get; set; }

        public DateTime TimeofApproval { get; set; }

        public string OrderStatus { get; set; }

        public string AdditionalComments { get; set; }
    }

}
