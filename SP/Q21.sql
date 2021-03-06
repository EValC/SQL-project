USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_percentfopersons]    Script Date: 3/10/2015 11:07:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_percentfopersons]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
SELECT  (COUNT(DISTINCT XZ.PERSONCODE)* 100)/COUNT(DISTINCT X.PERSONCODE) as Percentage 
FROM (SELECT  T.PERSONCODE,T.STORECODE,A1.CITY FROM TRANSACTIONS T,[ADDRESS] A1,[ADDRESS] A2, STORE S,PERSON P
 WHERE S.ADDRESSCODE = A1.ADDRESSCODE AND S.STORECODE = T.STORECODE AND P.ADDRESSCODE = A2.ADDRESSCODE AND P.PERSONCODE = T.PERSONCODE AND A1.CITY <> A2.CITY) AS XZ,
 (SELECT  T.PERSONCODE,T.STORECODE,A.CITY FROM TRANSACTIONS T,[ADDRESS] A, STORE S 
WHERE S.ADDRESSCODE = A.ADDRESSCODE AND S.STORECODE = T.STORECODE) AS X
END
