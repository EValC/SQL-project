USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[GetItemsStoresSold]    Script Date: 3/10/2015 11:01:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetItemsStoresSold]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select T.STORECODE,IC.ITEMCODE,sum(IC.QUANTITY) AS SOLD from TRANSACTIONS T,INCLUDES IC
	where IC.TRANSACTIONCODE=T.TRANSACTIONCODE
	group by IC.ITEMCODE, T.STORECODE
	order by  T.STORECODE asc,sum(IC.QUANTITY) desc , IC.ITEMCODE asc 
	
END
