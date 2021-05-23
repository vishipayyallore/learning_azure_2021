USE [MedsRUsDataStore]
GO

/****** Object:  Table [dbo].[MedOrders]    Script Date: 5/23/2021 10:00:16 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MedOrders](
	[Id] [uniqueidentifier] NOT NULL,
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
	[CreatedDateTime] [datetime2](7) NULL,
	[TimeofApproval] [datetime2](7) NULL,
	[OrderStatus] [varchar](50) NULL,
	[AdditionalComments] [varchar](100) NULL,
 CONSTRAINT [PK_MedOrders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[MedOrders] ADD  CONSTRAINT [DF_MedOrders_Id]  DEFAULT (newid()) FOR [Id]
GO

ALTER TABLE [dbo].[MedOrders] ADD  CONSTRAINT [DF_MedOrders_CreatedDateTime]  DEFAULT (getdate()) FOR [CreatedDateTime]
GO


