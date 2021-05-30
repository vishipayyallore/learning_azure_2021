CREATE PROCEDURE [dbo].[usp_create_med_order]
	@PatientName varchar(100) = 'No Name',
	@PatientDOB datetime2(7) = '',
	@PatientRoom numeric(18,0) = 0,
	@AttendingPhysicianName varchar(100) = '',
	@EmployeeInitiatingOrder varchar(100) = 'Physician Assistant 1',
	@IsPhysicianAssistant bit = 1,
	@IsNurse bit = 0,
	@MedicationName varchar(100) = '',
	@MedicationDosage varchar(100) = '',
	@MedicationFrequency numeric(18,0) = 0,
	@UrgencyRanking numeric(18,0) = 0,
	@CreatedDateTime datetime2(7) = '',
	@TimeofApproval datetime2(7) = NULL,
	@OrderStatus varchar(50) = 'Pending',
	@AdditionalComments varchar(100) = '',
    @Id uniqueidentifier output

AS
BEGIN
	
	SET NOCOUNT ON;

	set @Id = NEWID();

	INSERT INTO [dbo].[MedOrders] 
			([Id], [PatientName] ,[PatientDOB] ,[PatientRoom] ,[AttendingPhysicianName] 
			 ,[EmployeeInitiatingOrder] ,[IsPhysicianAssistant] ,[IsNurse] ,[MedicationName] 
			 ,[MedicationDosage] ,[MedicationFrequency] ,[UrgencyRanking] ,[CreatedDateTime] ,[TimeofApproval] 
			 ,[OrderStatus] ,[AdditionalComments])
     VALUES
           (@Id, @PatientName, @PatientDOB, @PatientRoom, @AttendingPhysicianName, @EmployeeInitiatingOrder
		   , @IsPhysicianAssistant, @IsNurse, @MedicationName, @MedicationDosage, @MedicationFrequency
		   , @UrgencyRanking, @CreatedDateTime, @TimeofApproval, @OrderStatus, @AdditionalComments);

END


