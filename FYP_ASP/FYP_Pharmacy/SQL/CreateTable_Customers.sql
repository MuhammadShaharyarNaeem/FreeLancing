use [PharmaMS]
go

if not exists (select * from sysobjects where name='Customer')
	create table Customer(
	 ID int not null,
	 Name varchar(30),
	 Description varchar(30),
	 Constraint [PK_CustomerID] primary key clustered (ID)
	)