IF DB_ID('Commerce') IS NOT NULL
USE [master]
DROP DATABASE [Commerce]
CREATE DATABASE [Commerce]
GO

USE [Commerce]


-- CONTRACTORS TABLE

IF EXISTS(SELECT * FROM sysobjects WHERE name='Contractors' and xtype='U')
DROP TABLE [Contractors]
CREATE TABLE [dbo].[Contractors] 
(
[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[FirstName] varchar(40),
[LastName] varchar(40),
[Email] varchar(40),
[Street] varchar(40),
[City] varchar(40),
[Country] varchar(40),	
[TaxNumber] varchar(40),
[NBRN] varchar(40),
[BankAccountNumber] varchar(100),
)
GO

-- Invoices, Invoice status, Payments

-- IF EXISTS(SELECT * FROM sysobjects WHERE name=''

-- 'Enum' tables

IF EXISTS(SELECT * FROM sysobjects WHERE name='IssueType' AND xtype='U') DROP TABLE [IssueType]
CREATE TABLE [IssueType]
(
[ID] INT PRIMARY KEY NOT NULL ,
[Name] varchar(20)
)
INSERT INTO IssueType([ID],[Name]) VALUES (0, 'From contractor')
INSERT INTO IssueType([ID],[Name]) VALUES (1, 'To contractor')
GO

DROP TABLE IF EXISTS [dbo].[PaymentStatus]
CREATE TABLE [dbo].[PaymentStatus]
(
[ID] INT PRIMARY KEY NOT NULL,
[Description] varchar(30) NOT NULL
)

INSERT INTO [PaymentStatus]([ID],[Description]) VALUES (0,'No payment')
INSERT INTO [PaymentStatus]([ID],[Description]) VALUES (1,'Partial payment')
INSERT INTO [PaymentStatus]([ID],[Description]) VALUES (2,'Paid')
INSERT INTO [PaymentStatus]([ID],[Description]) VALUES (3, 'Overpayment')

GO
-- 

IF EXISTS(SELECT * FROM sysobjects WHERE name='Invoices' AND xtype='U') DROP TABLE [Invoices]
CREATE TABLE [dbo].[Invoices]
(
[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[ContractorID] INT CONSTRAINT FK_ContractorInvoice FOREIGN KEY ([ContractorID]) REFERENCES Contractors(ID),
[IssueDate] DATETIME,
[PaymentDate] DATETIME,
[No] varchar(20),
[IssueTypeID] INT CONSTRAINT FK_IssueTypeInvoices FOREIGN KEY ([IssueTypeID]) REFERENCES IssueType(ID)
)

IF EXISTS(SELECT * FROM sysobjects WHERE name='InvoicesStatus' AND xtype='U') DROP TABLE [InvoicesStatus]
CREATE TABLE [dbo].[InvoicesStatus]
(
[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[PaymentStatusID] INT CONSTRAINT FK_PaymentStatusInvoiceStatus FOREIGN KEY (PaymentStatusID) REFERENCES PaymentStatus(ID)
)
GO

IF EXISTS(SELECT * FROM sysobjects WHERE name='Payments' AND xtype='U') DROP TABLE [Payments]
CREATE TABLE [dbo].[Payments]
(
[ID] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
[Value] INT NOT NULL,
[InvoiceID] INT CONSTRAINT FK_InvoiceIDPayments FOREIGN KEY ([InvoiceID]) REFERENCES [Invoices]([ID])
)
GO
