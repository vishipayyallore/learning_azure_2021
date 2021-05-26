CREATE TABLE [dbo].[MedOrders]
(
	[Id] [uniqueidentifier] DEFAULT (newid()) NOT NULL PRIMARY KEY, 
	[PatientName] [varchar](100) NULL,
	[PatientDOB] [datetime2](7) NULL,
	[PatientRoom] [numeric](18, 0) NULL,
	[AttendingPhysicianName] [varchar](100) NULL,
	[EmployeeInitiatingOrder] [varchar](100) NULL,
	[IsPhysicianAssistant] [bit] NULL,
	[IsNurse] [bit] NULL,
	[MedicationName] [varchar](100) NULL,
	[MedicationDosage] [varchar](100) NULL,
	[MedicationFrequency] [numeric](18, 0) NULL,
	[UrgencyRanking] [numeric](18, 0) NULL,
	[CreatedDateTime] [datetime2](7) DEFAULT (getdate()) NULL,
	[TimeofApproval] [datetime2](7) NULL,
	[OrderStatus] [varchar](50) NULL,
	[AdditionalComments] [varchar](100) NULL,
)