if exists (select * from sysdatabases where name='CarDealer')
		drop database "CarDealer"
go

if exists (select * from sysobjects where id = object_id('Transactions') and sysstat & 0xf = 3)
	drop table "Transactions"
go

if exists (select * from sysobjects where id = object_id('Cars') and sysstat & 0xf = 3)
	drop table "Cars"
go

if exists (select * from sysobjects where id = object_id('Menagers') and sysstat & 0xf = 3)
	drop table "Menagers"
go

if exists (select * from sysobjects where id = object_id('Clients') and sysstat & 0xf = 3)
	drop table "Clients"
go

CREATE DATABASE "CarDealer"
GO

use CarDealer
go

CREATE TABLE "Cars"(
	"CarID"		int IDENTITY(1,1)	NOT NULL,
	"Brand"		nvarchar (20)		NOT NULL,
	"Model"		nvarchar (20)		NOT NULL,
	"Price"		money				NOT NULL,
	"Milage"	float				NOT NULL,
	"Weight"	int					NOT NULL,
	"MaxSpeed"	int					NOT NULL,

	CONSTRAINT "PK_Cars" PRIMARY KEY  CLUSTERED ("CarID")
)
GO

CREATE  INDEX "Brand" ON "Cars"("Brand")
GO
CREATE  INDEX "Model" ON "Cars"("Model")
GO

CREATE TABLE "Menagers"(
	"MenagerID"		int IDENTITY(1,1)	NOT NULL,
	"Name"          nvarchar(20)		NOT NULL,
	"Surname"		nvarchar(30)		NOT NULL,
	"Salary"		money				NOT NULL

	CONSTRAINT "PK_Menagers" PRIMARY KEY  CLUSTERED ("MenagerID")
)
GO

CREATE  INDEX "Surname" ON "Menagers"("Surname")
GO

CREATE TABLE "Clients"(
	"ClientID"		int IDENTITY(1,1)	NOT NULL,
	"Name"          nvarchar(20)		NOT NULL,
	"Surname"		nvarchar(30)		NOT NULL,

	CONSTRAINT "PK_Clients" PRIMARY KEY  CLUSTERED ("ClientID")
)
GO

CREATE  INDEX "Surname" ON "Clients"("Surname")
GO

CREATE TABLE "Transactions"(
	"TransactionID"		int IDENTITY(1,1)	NOT NULL,
	"MenagerID"			int 				NOT NULL,
	"ClientID"			int 				NOT NULL,
	"CarID"				int 				NOT NULL,
	"Date"				date				NOT NULL, 

	CONSTRAINT "PK_Transactions" PRIMARY KEY  CLUSTERED ("TransactionID"),

	CONSTRAINT "FK_MenagerID" FOREIGN KEY ("MenagerID") 
	REFERENCES "Menagers" ("MenagerID")
	ON DELETE CASCADE,

	CONSTRAINT "ClientID" FOREIGN KEY ("ClientID") 
	REFERENCES "Clients" ("ClientID")
	ON DELETE CASCADE,

	CONSTRAINT "CarID" FOREIGN KEY ("CarID") 
	REFERENCES "Cars" ("CarID")
	ON DELETE CASCADE
)
GO

CREATE  INDEX "MenagerID" ON "Transactions"("MenagerID")
GO
CREATE  INDEX "ClientID" ON "Transactions"("ClientID")
GO
CREATE  INDEX "CarID" ON "Transactions"("CarID")
GO
CREATE  INDEX "Date" ON "Transactions"("Date")
GO