CREATE OR ALTER   PROCEDURE [dbo].[usp_update_med_order_by_id]
	@Id uniqueidentifier,
	@AdditionalComments varchar(100) = '',
	@TimeofApproval datetime2(7)
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE [dbo].[MedOrders] 
		SET [OrderStatus] = 'Approved', [AdditionalComments] = @AdditionalComments, [TimeofApproval] = @TimeofApproval
	WHERE
		Id = @Id;

	SELECT @@ROWCOUNT;

END
