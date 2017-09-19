USE [PortfolioDB]
GO

/****** Object:  StoredProcedure [dbo].[spSetPersonalData]    Script Date: 9/19/2017 12:03:15 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spSetPersonalData] (
@SaveOption AS Int,
@ID AS Int,
@Name AS VarChar(30) = NULL,
@Phone AS VarChar(20) = NULL,
@Nid AS VarChar(25) = NULL,
@Gender AS VarChar(10) = NULL,
@DOB AS DateTime = NULL,
@Password AS VarChar(20) = NULL,
@Email AS VarChar(20) = NULL,
@Photo AS VarChar(30) = NULL,
@Role AS VarChar(10) = NULL
)
AS
DECLARE @INSERT_ROW AS Int
DECLARE @UPDATE_ROW AS Int
SET @INSERT_ROW = 1
SET @UPDATE_ROW = 2

IF @SaveOption = @INSERT_ROW
BEGIN
	INSERT INTO PersonalData( Name, Phone, Nid, Gender, DOB, Password, Email, Photo, Role) 
	VALUES( @Name, @Phone, @Nid, @Gender, @DOB, @Password, @Email, @Photo, @Role)
END

ELSE IF @SaveOption = @UPDATE_ROW
BEGIN
	IF EXISTS (SELECT * FROM PersonalData WHERE ID = @ID )
	BEGIN
		UPDATE PersonalData SET
			
			Name = @Name,
			Phone = @Phone,
			Nid = @Nid,
			Gender = @Gender,
			DOB = @DOB,
			Password = @Password,			
			Photo = @Photo,
			Role = @Role
		WHERE ID = @ID
	END
	ELSE
	BEGIN
		INSERT INTO PersonalData( Name, Phone, Nid, Gender, DOB, Password, Email, Photo, Role) 
			VALUES( @Name, @Phone, @Nid, @Gender, @DOB, @Password, @Email, @Photo, @Role)
	END
END
GO


