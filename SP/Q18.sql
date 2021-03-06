USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_totalsale]    Script Date: 3/10/2015 11:06:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_totalsale](@storecode int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT sum(JON.PRIC * JON.QUANT) AS TOTALSALES 
FROM  (SELECT  SUM(JN.QUANT) QUANT, JN.PRIC PRIC, JN.STRCOD, JN.TRANCOD
FROM (SELECT J.QUANT,J.PRIC, J.STRCOD, J.TRANCOD 
FROM (SELECT IT.NAME NAME,T.STORECODE STRCOD, IT.PRICE PRIC, I.QUANTITY QUANT, T.TRANSACTIONCODE TRANCOD
 FROM ITEM IT, INCLUDES I, TRANSACTIONS T 
WHERE I.ITEMCODE = IT.ITEMCODE AND T.TRANSACTIONCODE=I.TRANSACTIONCODE AND T.STORECODE = @storecode) AS J) AS JN GROUP BY  JN.PRIC, JN.STRCOD, JN.TRANCOD ) AS JON
 ORDER BY TOTALSALES desc

END
