USE [Assignment1]
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCustomersCities]    Script Date: 3/10/2015 11:00:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[sp_GetCustomersCities](@city varchar(50))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT MAX(P.DOB) AS 'MAX DOB', MIN(P.DOB) AS 'MIN DOB' 
	FROM ADDRESS A, PERSON P
	WHERE A.ADDRESSCODE = P.ADDRESSCODE AND CITY= @city
END
