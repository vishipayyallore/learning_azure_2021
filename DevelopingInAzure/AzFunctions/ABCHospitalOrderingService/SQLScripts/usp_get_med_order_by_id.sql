CREATE OR ALTER   PROCEDURE [dbo].[usp_get_med_order_by_id]
	@Id uniqueidentifier
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT
		[Id], [OrderStatus], [AdditionalComments]
	FROM
		[dbo].[MedOrders] 
	WHERE
		Id = @Id;

END
