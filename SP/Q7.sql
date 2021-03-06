USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetBestSeller]    Script Date: 3/10/2015 11:01:40 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetBestSeller]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  top(1) I.NAME, sum(IC.QUANTITY) from INCLUDES IC,ITEM I
	where I.ITEMCODE=IC.ITEMCODE
	group by I.NAME
order by  sum(IC.QUANTITY) desc,I.NAME asc
END
