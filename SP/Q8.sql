USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetMostPopular]    Script Date: 3/10/2015 11:01:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetMostPopular]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT top(1) I.BRAND,count(IC.QUANTITY) AS cnt from ITEM I,INCLUDES IC
	where I.ITEMCODE=IC.ITEMCODE
	group by I.BRAND
	order by cnt desc
END
