use CarDealer

set quoted_identifier on
go
set identity_insert "Cars" on
go
ALTER TABLE "Cars" NOCHECK CONSTRAINT ALL
go
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(1,'BMW','340i Gran Turismo','182000','9.1','1675','229')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(2,'BMW','M850i xDrive','489000','11.4','1965','250')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(3,'BMW','X5 M50i','450000','12.5','2325','250')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(4,'Audi','A3 Sportback','120000','4.5','1800','210')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(5,'Audi','RS3 Limousine','299500','9.5','1610','250')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(6,'Audi','A8','443000','8.5','2050','250')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(7,'Volkswagen','Golf','85000','4.0','1255','202')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(8,'Volkswagen','Tiguan','108750','7.8','1510','204')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(9,'Volkswagen','Touareg','285830','10.2','2005','250')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(10,'Volkswagen','T-Roc','92290','5.44','1293','187')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(11,'Fiat','Tipo','62000','3.8','1350','181')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(12,'Ford','Focus','82900','5.3','1320','190')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(13,'Ford','Mustang','199500','8.9','1500','235')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(14,'Skoda','Octavia','95000','5.3','1450','210')
INSERT "Cars"("CarID","Brand","Model","Price","Milage","Weight","MaxSpeed") VALUES(15,'Ferrari','812 GTS','1300000','15.8','1800','340')
set identity_insert "Cars" off
go
ALTER TABLE "Cars" CHECK CONSTRAINT ALL
go

set quoted_identifier on
go
set identity_insert "Menagers" on
go
ALTER TABLE "Menagers" NOCHECK CONSTRAINT ALL
go
INSERT "Menagers"("MenagerID","Name","Surname","Salary") VALUES(1,'Jan','Kowalksi','8500')
INSERT "Menagers"("MenagerID","Name","Surname","Salary") VALUES(2,'Tomasz','Lewandowski','6500')
INSERT "Menagers"("MenagerID","Name","Surname","Salary") VALUES(3,'Andrzej','Nowak','6500')
INSERT "Menagers"("MenagerID","Name","Surname","Salary") VALUES(4,'Micha³','Kasztan','12000')
INSERT "Menagers"("MenagerID","Name","Surname","Salary") VALUES(5,'Anna','Stolarz','7200')
set identity_insert "Menagers" off
go
ALTER TABLE "Menagers" CHECK CONSTRAINT ALL
go

set quoted_identifier on
go
set identity_insert "Clients" on
go
ALTER TABLE "Clients" NOCHECK CONSTRAINT ALL
go
INSERT "Clients"("ClientID","Name","Surname") VALUES(1,'Krzysztof','Krawczyk')
INSERT "Clients"("ClientID","Name","Surname") VALUES(2,'Adam','Nowakowski')
INSERT "Clients"("ClientID","Name","Surname") VALUES(3,'Kevin','Schulz')
INSERT "Clients"("ClientID","Name","Surname") VALUES(4,'Damian','Wrona')
INSERT "Clients"("ClientID","Name","Surname") VALUES(5,'Kamil','Peszko')
INSERT "Clients"("ClientID","Name","Surname") VALUES(6,'Tomasz','Dzik')
INSERT "Clients"("ClientID","Name","Surname") VALUES(7,'Natalia','Bis')
INSERT "Clients"("ClientID","Name","Surname") VALUES(8,'Karolina','Niedzielska')
INSERT "Clients"("ClientID","Name","Surname") VALUES(9,'Antoni','Zarzeczny')
INSERT "Clients"("ClientID","Name","Surname") VALUES(10,'Julia','Nowak')
set identity_insert "Clients" off
go
ALTER TABLE "Clients" CHECK CONSTRAINT ALL
go

set quoted_identifier on
go
set identity_insert "Transactions" on
go
ALTER TABLE "Transactions" NOCHECK CONSTRAINT ALL
go
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(1,'1','10','12','2019-03-12')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(2,'2','9','1','2019-04-13')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(3,'3','6','11','2019-04-15')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(4,'2','7','8','2019-06-25')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(5,'5','8','4','2019-08-01')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(6,'5','1','2','2019-08-01')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(7,'2','2','5','2019-09-19')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(8,'3','3','11','2019-12-22')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(9,'4','4','13','2020-01-17')
INSERT "Transactions"("TransactionID","MenagerID","ClientID","CarID","Date") VALUES(10,'4','5','3','2020-04-14')
set identity_insert "Transactions" off
go
ALTER TABLE "Transactions" CHECK CONSTRAINT ALL
go