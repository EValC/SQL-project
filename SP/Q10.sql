USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetItemDeatils]    Script Date: 3/10/2015 11:03:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetItemDeatils](@transactioncode varchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select I.NAME,INC.QUANTITY,I.PRICE,(INC.QUANTITY*I.PRICE) TOTAL from ITEM I,INCLUDES INC,TRANSACTIONS T
	WHERE T.TRANSACTIONCODE=INC.TRANSACTIONCODE AND I.ITEMCODE=INC.ITEMCODE AND  T.TRANSACTIONCODE=@transactioncode
	order by I.NAME asc
 END
