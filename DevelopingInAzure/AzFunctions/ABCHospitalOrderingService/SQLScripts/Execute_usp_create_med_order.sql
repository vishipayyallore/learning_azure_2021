USE [MedsRUsDataStore]
GO

DECLARE	@Id uniqueidentifier;

EXEC	[dbo].[usp_create_med_order]
		@PatientName = N'Shiva',
		@Id = @Id OUTPUT

SELECT	@Id as N'@Id'

GO
