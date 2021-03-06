USE [PortfolioDB]
GO
/****** Object:  StoredProcedure [dbo].[spGetPersonalData]    Script Date: 9/19/2017 12:45:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[spGetPersonalData] (
@QryOption AS Int,
@ID AS Int
)
AS

DECLARE @BY_ALL AS Int
DECLARE @BY_PRIMARYKEYS AS Int
SET @BY_ALL = 1
SET @BY_PRIMARYKEYS = 2

IF @QryOption = @BY_ALL
BEGIN
	SELECT ID, Name, Phone, Nid, Gender, DOB, Password, Email, Photo, Role
	FROM PersonalData
END
ELSE IF @QryOption = @BY_PRIMARYKEYS
BEGIN
	SELECT ID, Name, Phone, Nid, Gender, DOB, Password, Email, Photo, Role
	FROM PersonalData
	WHERE ID = @ID
END