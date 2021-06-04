CREATE PROCEDURE [dbo].[usp_get_med_orders_for_approval]
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		[Id], [PatientName] ,[PatientDOB] ,[PatientRoom] ,[AttendingPhysicianName] ,[EmployeeInitiatingOrder] ,[IsPhysicianAssistant] ,[IsNurse] 
			,[MedicationName] ,[MedicationDosage] ,[MedicationFrequency] ,[UrgencyRanking] ,[CreatedDateTime] ,[TimeofApproval] ,[OrderStatus] 
			,[AdditionalComments], [PictureUrl]
	FROM
		[dbo].[MedOrders] 
	WHERE
		[OrderStatus] <> 'Approved';

END
