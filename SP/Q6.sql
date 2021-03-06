USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_FindRunnuingOutItems]    Script Date: 3/10/2015 11:01:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_FindRunnuingOutItems]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT EN.STORECODE,EN.ITEMCODE,EN.QUANTITY from EXISTS_IN EN
	where EN.QUANTITY<5
	ORDER BY EN.STORECODE ASC,EN.ITEMCODE asc,en.QUANTITY asc
END
