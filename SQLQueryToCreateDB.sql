CREATE DATABASE LTHT_USER

USE LTHT_USER

CREATE TABLE USERS
(
	UserId INT IDENTITY(1,1) primary key,
	UserName nvarchar(100),
	PassWord nvarchar(100),
	Email nvarchar(100)
)



-- SELECT * FROM USERS