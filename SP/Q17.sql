USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_itemusually]    Script Date: 3/13/2015 1:56:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_itemusually](@itemcode int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ITEM_COUNT.TOPITEM FROM (SELECT TOP(1) ITEMCODE AS TOPITEM, COUNT(ITEMCODE) AS COUNT FROM INCLUDES 
	WHERE TRANSACTIONCODE IN (
SELECT TRANSACTIONCODE FROM INCLUDES
WHERE ITEMCODE = @itemcode)
AND ITEMCODE <> @itemcode
GROUP BY ITEMCODE
ORDER BY COUNT DESC) AS ITEM_COUNT
END
