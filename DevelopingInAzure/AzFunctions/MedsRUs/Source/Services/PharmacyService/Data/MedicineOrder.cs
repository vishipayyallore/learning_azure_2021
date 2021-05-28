using System;

namespace PharmacyService.Data
{

    public class MedicineOrder
    {
        public Guid id { get; set; }

        public string PatientName { get; set; } = $"Patient {new Random().Next(1, 999)}";

        public DateTime PatientDOB { get; set; } = DateTime.Now.AddYears(-(new Random().Next(5, 20)));

        public string AttendingPhysicianName { get; set; } = $"Physician {new Random().Next(1, 5)}";

        public string MedicationName { get; set; } = "Aspirin";

        public string MedicationDosage { get; set; } = "81 mg";

        public int MedicationFrequency { get; set; } = new Random().Next(1, 3);

        public int UrgencyRanking { get; set; } = new Random().Next(1, 5);

        public string LotNumber { get; set; } = "";

        public string PharmacyOrderStatus { get; set; } = "Pending";

        public DateTime PharmacyTimeofApproval { get; set; }

        public string PharmacyAdditionalComments { get; set; } = "Please approve";
    }

}
