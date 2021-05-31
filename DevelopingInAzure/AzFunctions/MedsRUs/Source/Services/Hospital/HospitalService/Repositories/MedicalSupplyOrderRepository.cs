using HospitalService.Data;
using HospitalService.Interfaces;
using System;
using System.Data;
using System.Data.SqlClient;

namespace HospitalService.Repositories
{
    public class MedicalSupplyOrderRepository : IMedicalSupplyOrderRepository
    {

        public bool PlaceMedicalSupplyOrder(string connectionString, MedicineOrder medicineOrder)
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

                        medicineOrder.TimeofApproval = DateTime.Now;
                        command.Parameters.AddWithValue("@TimeofApproval",
                            medicineOrder.TimeofApproval).SqlDbType = SqlDbType.DateTime2;
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

        public MedicineOrder RetrieveMedicalSupplyOrder(string connectionString, Guid id)
        {
            MedicineOrder medicineOrder = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand()
                {
                    CommandText = "[dbo].[usp_get_med_order_by_id]",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id",
                    id).SqlDbType = SqlDbType.UniqueIdentifier;

                connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    dataReader.Read();

                    medicineOrder = new MedicineOrder
                    {
                        Id = dataReader.GetGuid(0),

                        PatientName = dataReader.GetString(1),

                        PatientDOB = dataReader.GetDateTime(2),

                        PatientRoom = (int)dataReader.GetDecimal(3),

                        AttendingPhysicianName = dataReader.GetString(4),

                        EmployeeInitiatingOrder = dataReader.GetString(5),

                        IsPhysicianAssistant = dataReader.GetBoolean(6),

                        IsNurse = dataReader.GetBoolean(7),

                        MedicationName = dataReader.GetString(8),

                        MedicationDosage = dataReader.GetString(9),

                        MedicationFrequency = (int)dataReader.GetDecimal(10),

                        UrgencyRanking = (int)dataReader.GetDecimal(11),

                        CreatedDateTime = dataReader.GetDateTime(12),

                        TimeofApproval = dataReader.IsDBNull(dataReader.GetOrdinal("TimeofApproval")) ? DateTime.Now : dataReader.GetDateTime(13),

                        OrderStatus = dataReader.GetString(14),

                        AdditionalComments = dataReader.GetString(15)
                    };
                }
            }

            return medicineOrder;
        }

        public bool ApproveMedicalSupplyOrder(string connectionString, MedicineOrderApproval medicineOrderApproval)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand()
                {
                    CommandText = "[dbo].[usp_update_med_order_by_id]",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id",
                    medicineOrderApproval.Id).SqlDbType = SqlDbType.UniqueIdentifier;

                command.Parameters.AddWithValue("@OrderStatus",
                    medicineOrderApproval.OrderStatus).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@TimeofApproval",
                    medicineOrderApproval.TimeofApproval).SqlDbType = SqlDbType.DateTime2;

                command.Parameters.AddWithValue("@AdditionalComments",
                    medicineOrderApproval.AdditionalComments).SqlDbType = SqlDbType.VarChar;

                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool ModifyOrderWithPharmacyUpdates(string connectionString, MedicineOrderPharmacyApproval medicineOrderPharmacyApproval)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                SqlCommand command = new SqlCommand()
                {
                    CommandText = "[dbo].[usp_update_med_order_with_pharmacy_updates]",
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id",
                    medicineOrderPharmacyApproval.Id).SqlDbType = SqlDbType.UniqueIdentifier;

                command.Parameters.AddWithValue("@PharmacyOrderStatus",
                    medicineOrderPharmacyApproval.PharmacyOrderStatus).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@PharmacyTimeofApproval",
                    medicineOrderPharmacyApproval.PharmacyTimeofApproval).SqlDbType = SqlDbType.DateTime2;

                command.Parameters.AddWithValue("@PharmacyAdditionalComments",
                    medicineOrderPharmacyApproval.PharmacyAdditionalComments).SqlDbType = SqlDbType.VarChar;

                connection.Open();
                command.ExecuteNonQuery();
            }

            return true;
        }

    }

}
