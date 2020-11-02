use [PharmaMS]
go

if not exists (select * from sysobjects where name='PurchaseDetails')
	create table PurchaseDetails(
	 ID int not null identity,
	 Name varchar(30),
	 PurchaseDate datetime,
	 Amount float,
	 Constraint [PK_PurchaseDetailsID] primary key clustered (ID)
	)