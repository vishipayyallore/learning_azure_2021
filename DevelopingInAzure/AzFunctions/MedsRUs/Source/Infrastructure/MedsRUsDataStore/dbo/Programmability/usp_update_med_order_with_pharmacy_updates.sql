CREATE PROCEDURE [dbo].[usp_update_med_order_with_pharmacy_updates]
	@Id uniqueidentifier,
	@PharmacyTimeofApproval datetime2(7),
	@PharmacyOrderStatus varchar(50),
	@PharmacyAdditionalComments varchar(100)
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE [dbo].[MedOrders] 
		SET [PharmacyTimeofApproval] = @PharmacyTimeofApproval, [PharmacyOrderStatus] = @PharmacyOrderStatus
			, [PharmacyAdditionalComments] = @PharmacyAdditionalComments
	WHERE
		Id = @Id;

	SELECT @@ROWCOUNT;

END
