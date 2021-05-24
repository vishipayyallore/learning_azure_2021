using MedsRUs.Data;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalService.Data
{
    public class MedicalSupplyOrderRepository
    {

        public static bool PlaceMedicalSupplyOrder(string connectionString, MedicineOrder medicineOrder)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand()
                {
                    CommandText = "[dbo].[usp_create_med_order]",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@PatientName",
                    medicineOrder.PatientName).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@PatientDOB",
                    medicineOrder.PatientDOB).SqlDbType = SqlDbType.DateTime2;

                command.Parameters.AddWithValue("@PatientRoom",
                    medicineOrder.PatientRoom).SqlDbType = SqlDbType.Int;

                command.Parameters.AddWithValue("@AttendingPhysicianName",
                    medicineOrder.AttendingPhysicianName).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@EmployeeInitiatingOrder",
                    medicineOrder.EmployeeInitiatingOrder).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@IsPhysicianAssistant",
                    medicineOrder.IsPhysicianAssistant).SqlDbType = SqlDbType.Bit;

                medicineOrder.IsNurse = !medicineOrder.IsPhysicianAssistant;
                command.Parameters.AddWithValue("@IsNurse",
                    medicineOrder.IsNurse).SqlDbType = SqlDbType.Bit;

                command.Parameters.AddWithValue("@MedicationName",
                    medicineOrder.MedicationName).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@MedicationDosage",
                    medicineOrder.MedicationDosage).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@MedicationFrequency",
                    medicineOrder.MedicationFrequency).SqlDbType = SqlDbType.Int;

                command.Parameters.AddWithValue("@UrgencyRanking",
                    medicineOrder.UrgencyRanking).SqlDbType = SqlDbType.Int;

                command.Parameters.AddWithValue("@CreatedDateTime",
                    medicineOrder.CreatedDateTime).SqlDbType = SqlDbType.DateTime2;

                if (medicineOrder.IsPhysicianAssistant)
                {
                    if (new Random().Next(1, 999) >= 500)
                    {
                        medicineOrder.OrderStatus = "Approved";

                        medicineOrder.AdditionalComments = "Assistance Overriding the approval";
                    }
                }

                command.Parameters.AddWithValue("@OrderStatus",
                    medicineOrder.OrderStatus).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@AdditionalComments",
                    medicineOrder.AdditionalComments).SqlDbType = SqlDbType.VarChar;

                // Output
                SqlParameter recordId = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(recordId);

                connection.Open();
                command.ExecuteNonQuery();

                medicineOrder.Id = Guid.Parse(recordId.Value.ToString());
            }

            return true;
        }

    }

}
