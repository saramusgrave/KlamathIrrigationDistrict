/********************************************Create Database KIDTEMPLATE*****************************************************/
use master 
DROP DATABASE IF EXISTS KIDTEMPLATE 
CREATE DATABASE KIDTEMPLATE 
USE KIDTEMPLATE 

--DitchRider
CREATE TABLE DitchRider (
DitchRiderID int not null IDENTITY (1,1),
DitchRiderFirstName varchar (50),
DitchRiderLastName varchar (50),
DitchRiderPhoneNumber varchar(13) CHECK (DitchRiderPhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
PRIMARY KEY (DitchRiderID));
GO

--Customers Table
CREATE TABLE Customers (
CustomerID int not null IDENTITY (1,1),
CustomerFirstName varchar (50),
CustomerLastName varchar (50),
Address1 varchar (100) null,
Address2 varchar (100) null,
City varchar (50) null,
State varchar (2) null,
Zip int null CHECK (Zip LIKE '[0-9][0-9][0-9][0-9][0-9]'),
CustomerPhoneNumber varchar (13) CHECK ( CustomerPhoneNumber LIKE '[0-9][0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]'),
CustomerEmail varchar (255) null,
PRIMARY KEY (CustomerID));
GO

--CustomerHistory
CREATE TABLE CustomerHistory (
CustomerHistoryID int not null IDENTITY (1,1),
CustomerID int not null,
Date date not null,
WaterUsage decimal not null,
PRIMARY KEY (CustomerHistoryID),
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID));
GO

--CustomerRequest
CREATE TABLE CustomerRequest (
RequestID int not null IDENTITY (1,1),
CustomerID int not null,
CustomerFirstName varchar (50),
CustomerLastName varchar (50),
WaterAmount decimal not null,
WaterOnDate date not null,
WaterOffDate date not null,
Comments varchar (255) null,
DitchRiderID int not null,
WaterOn date null,
WaterOff date null,
PRIMARY KEY (RequestID),
FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID),
FOREIGN KEY (DitchRiderID) REFERENCES DitchRider(DitchRIderID));
GO

/*********************************************Enter Data into KIDTEMPLATE**************************************/
--Insert into DitchRider
INSERT INTO DitchRider (DitchRiderFirstName, DitchRiderLastName, DitchRiderPhoneNumber)
VALUES
('Jeff', 'Dickson', '555-555-5555'),
('Allen', 'Wallace', '666-666-6666'),
('Fin', 'Bob', '777-777-7777');
GO

--Insert into Customers and Customer History 
DECLARE @CustomerID int;
INSERT INTO Customers (CustomerFirstName, CustomerLastName, Address1, Address2, City, State, Zip, CustomerPhoneNumber, CustomerEmail)
VALUES
('Sara', 'Musgrave', 'N. El Dorado', NULL, 'Klamath Falls', 'OR', 97601, '916-996-4921', 'sara.musgrave@oit.edu')
SET @CustomerID = @@IDENTITY

INSERT INTO CustomerHistory (CustomerID, Date, WaterUsage)
VALUES 
(@CustomerID, '5-3-2017', 5.5)
INSERT INTO Customers(CustomerFirstName, CustomerLastName,Address1, Address2, City, State, Zip, CustomerPhoneNumber, CustomerEmail)
VALUES 
('Thomas', 'Holland' , 'N. El Dorado', NULL, 'Klamath Falls', 'OR', 97601, '111-111-1111', 'thomas.holland2@oit.edu')
SET @CustomerID = @@IDENTITY
INSERT INTO CustomerHistory (CustomerID, Date, WaterUsage)
VALUES 
(@CustomerID, '5-4-2017', 6.6)
INSERT INTO Customers (CustomerFirstName, CustomerLastName,Address1, Address2, City, State, Zip, CustomerPhoneNumber, CustomerEmail)
VALUES
('Travis', 'Miller', 'N. El Doraldo', NULL, 'Klamath Falls', 'OR', 97601, '222-222-2222', 'travis.miller@oit.edu')
SET @CustomerID = @@IDENTITY
INSERT INTO CustomerHistory (CustomerID, Date, WaterUsage)
VALUES 
(@CustomerID, '5-17-2017', 7.7)
Go

--Insert into CustomerRequest
INSERT INTO CustomerRequest(CustomerID, CustomerFirstName, CustomerLastName, WaterAmount, WaterOnDate, WaterOffDate, Comments, DitchRiderID)
VALUES
(1,'Sara', 'Musgrave',1,'5/10/17','5/12/17','hi',1),
(2,'Thomas','Holland',5,'5/15/17','5/16/17', 'bye',2),
(3,'Travis','Miller', 8, '5/20/17','5/25/17', 'haha',3);
GO

/*Procedures*/
--Grab Dates form CustomerHistory 
CREATE PROCEDURE sp_CustomerHistory_Get
@RequestID int,
@WaterAmount int,
@WaterOnDate date, 
@WaterOffDate date,
@Comments varchar (255)
AS
SELECT @RequestID, @WaterAmount, @WaterOnDate, @WaterOffDate, @Comments FROM CustomerHistory;
GO

--Stored Procedure that changes name of customer/add customer
CREATE PROCEDURE sp_Cusomters_InsertUpdate
@CustomerID int = NULL,
@CustomerFirstName varchar (50), 
@CustomerLastName varchar (50), 
@Address1 varchar(100),
@Address2 varchar(100),
@City varchar (50),
@State varchar (2),
@Zip int,
@CustomerPhoneNumber varchar (10),
@CustomerEmail varchar (255)
AS
IF @CustomerID IS NULL
BEGIN 
INSERT INTO Customers (CustomerFirstName, CustomerLastName, Address1, Address2, City, State, Zip, CustomerPhoneNumber, CustomerEmail)
VALUES 
(@CustomerFirstName,@CustomerLastName, @Address1,@Address2,@City,@State, @Zip,@CustomerPhoneNumber,@CustomerEmail)
END
ELSE
BEGIN 
UPDATE Customers SET
CustomerFirstName = @CustomerFirstName, CustomerLastName = @CustomerLastName, Address1 = @Address1, Address2 = @Address2, City = @City, State = @State, Zip = @Zip, CustomerPhoneNumber = @CustomerPhoneNumber, CustomerEmail = @CustomerEmail
WHERE CustomerID = @CustomerID
END 
Go

--Delete Request or edit a request
CREATE PROCEDURE sp_CustomerRequest_CreateDelete
@WaterAmount decimal, 
@WaterOnDate date,
@WaterOffDate date,
@Comments varchar (255)
AS
INSERT INTO CustomerRequest (WaterAmount, WaterOnDate,WaterOffDate, Comments)
VALUES 
(@WaterAmount, @WaterOnDate, @WaterOffDate, @Comments)
Go

--DitchRider updates the WaterOn WaterOff in CustoemrRequest Table.
CREATE PROCEDURE sp_CustomerRequest_SetWaterTImes
@WaterOn date,
@WaterOff date
AS
INSERT INTO CustomerRequest (WaterOn, WaterOff)
VALUES 
(@WaterOn, @WaterOff)
GO

--View Data
SELECT * FROM CustomerHistory
SELECT * FROM CustomerRequest
SELECT * FROM Customers
SELECT * FROM DitchRider