CREATE DATABASE Bai_tap_ly_thuyet_3
GO

USE Bai_tap_ly_thuyet_3
GO

CREATE TABLE USERS
(
	UserId INT IDENTITY(1,1) primary key,
	UserName nvarchar(100),
	PassWord nvarchar(100),
	Email nvarchar(100),
	FullName nvarchar(150),
	BirthDay date
)
