using System;

namespace HospitalService.Data
{

    public class MedicineOrder
    {
        public Guid Id { get; set; }

        public string PatientName { get; set; } = $"Patient {new Random().Next(1, 999)}";

        public DateTime PatientDOB { get; set; } = DateTime.Now.AddYears(-(new Random().Next(5, 20)));

        public int PatientRoom { get; set; } = new Random().Next(101, 999);

        public string AttendingPhysicianName { get; set; } = $"Physician {new Random().Next(1, 5)}";

        public string EmployeeInitiatingOrder { get; set; } = $"Assistant {new Random().Next(1, 5)}";

        public bool IsPhysicianAssistant { get; set; } = new Random().Next(1, 999) >= 500;

        public bool IsNurse { get; set; } = false;

        public string MedicationName { get; set; } = "Aspirin";

        public string MedicationDosage { get; set; } = $"{new Random().Next(50, 500)} mg";

        public int MedicationFrequency { get; set; } = new Random().Next(1, 3);

        public int UrgencyRanking { get; set; } = new Random().Next(1, 5);

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

        public DateTime TimeofApproval { get; set; }

        public string OrderStatus { get; set; } = "Pending";

        public string AdditionalComments { get; set; } = "Please approve";
    }

}
