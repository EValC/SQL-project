USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_bestdate]    Script Date: 3/10/2015 11:06:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_bestdate](@storecode int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select J.DATE from (SELECT TOP(1) TRANSACTION_DATE AS DATE,SUM(IC.QUANTITY*I.PRICE) AS SALES from TRANSACTIONS T,INCLUDES IC,ITEM I
WHERE  IC.TRANSACTIONCODE=T.TRANSACTIONCODE AND T.STORECODE=@storecode
GROUP BY TRANSACTION_DATE
ORDER BY SALES DESC) as J
END
