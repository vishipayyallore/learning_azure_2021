using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.ServiceBus;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using OrderService.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;

namespace OrderService
{
    public static class PlacePharmaceuticalOrders
    {

        [FunctionName("PlacePharmaceuticalOrders")]
        //[return: ServiceBus("medicialsuppyorders", Connection = "ServiceBusConnection")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [ServiceBus("medicialsuppyorders", Connection = "ServiceBusConnection", 
            EntityType = EntityType.Queue)] IAsyncCollector<MedicineOrder> medicialSuppyOrders,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function request received for medical order.");

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            MedicineOrder medicineOrder = JsonConvert.DeserializeObject<MedicineOrder>(requestBody);

            string connectionString = Environment
                .GetEnvironmentVariable("ConnectionStrings:SQLAZURECONNSTR_SqlServerConnection", EnvironmentVariableTarget.Process);

            PlaceMedicalSupplyOrder(connectionString, medicineOrder);

            string servicebusConnection = Environment
                .GetEnvironmentVariable("ServiceBusConnection", EnvironmentVariableTarget.Process);

            await medicialSuppyOrders.AddAsync(medicineOrder);

            log.LogInformation("C# HTTP trigger function placed the medical order.");

            return new OkObjectResult(medicineOrder);
        }

        private static bool PlaceMedicalSupplyOrder(string connectionString, MedicineOrder medicineOrder)
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
                    medicineOrder.OrderStatus = "Approved";

                    medicineOrder.AdditionalComments = "Assistance Overriding the approval";
                }

                command.Parameters.AddWithValue("@OrderStatus",
                    medicineOrder.OrderStatus).SqlDbType = SqlDbType.VarChar;

                command.Parameters.AddWithValue("@AdditionalComments",
                    medicineOrder.AdditionalComments).SqlDbType = SqlDbType.VarChar;

                // Output Parameter
                SqlParameter recordId = new SqlParameter
                {
                    ParameterName = "@Id",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    Direction = ParameterDirection.Output
                };

                //add the parameter to the SqlCommand object
                command.Parameters.Add(recordId);

                connection.Open();
                command.ExecuteNonQuery();

                medicineOrder.Id = Guid.Parse(recordId.Value.ToString());
                Console.WriteLine("Newely Generated Student ID : " + recordId.Value.ToString());
            }

            return true;
        }

        private static string GetEnvironmentVariable(string name)
        {
            return $"{name} = {System.Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process)}";
        }


    }

}


//log.LogInformation(GetEnvironmentVariable("AzureWebJobsStorage"));
//log.LogInformation(GetEnvironmentVariable("ConnectionStrings:SQLAZURECONNSTR_SqlServerConnection"));
