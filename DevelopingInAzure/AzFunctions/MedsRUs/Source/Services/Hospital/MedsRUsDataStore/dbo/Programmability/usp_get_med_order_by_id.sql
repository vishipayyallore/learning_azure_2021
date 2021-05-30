CREATE PROCEDURE [dbo].[usp_get_med_order_by_id]
	@Id uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		[Id], [PatientName] ,[PatientDOB] ,[PatientRoom] ,[AttendingPhysicianName] ,[EmployeeInitiatingOrder] 
		,[IsPhysicianAssistant] ,[IsNurse] ,[MedicationName] ,[MedicationDosage] ,[MedicationFrequency] 
		,[UrgencyRanking] ,[CreatedDateTime] ,[TimeofApproval] ,[OrderStatus] ,[AdditionalComments]
	FROM
		[dbo].[MedOrders] 
	WHERE
		Id = @Id;

END
