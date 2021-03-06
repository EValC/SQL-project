USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPersonsCities]    Script Date: 3/10/2015 11:00:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetPersonsCities]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT A.CITY,COUNT(P.PERSONCODE) AS NOOFPERSONS from ADDRESS A,PERSON P
	WHERE P.ADDRESSCODE=A.ADDRESSCODE
	GROUP BY A.CITY
ORDER BY NOOFPERSONS desc,A.CITY asc
	

END
