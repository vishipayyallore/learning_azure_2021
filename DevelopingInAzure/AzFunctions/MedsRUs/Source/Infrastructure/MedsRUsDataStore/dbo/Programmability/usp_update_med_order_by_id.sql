CREATE PROCEDURE [dbo].[usp_update_med_order_by_id]
	@Id uniqueidentifier,
	@OrderStatus varchar(50),
	@TimeofApproval datetime2(7),
	@AdditionalComments varchar(100)
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE [dbo].[MedOrders] 
		SET [TimeofApproval] = @TimeofApproval, [OrderStatus] = @OrderStatus
			, [AdditionalComments] = @AdditionalComments
	WHERE
		Id = @Id;

	SELECT @@ROWCOUNT;

END
