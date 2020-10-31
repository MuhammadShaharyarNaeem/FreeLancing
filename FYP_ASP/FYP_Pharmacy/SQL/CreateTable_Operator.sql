use PharmaMS
go 

if not exists (select * from sysobjects where name='Operator')
	create table Operator
	(
		ID int not null identity,
		Name varchar(30),
		Email varchar(30),
		ContactNumber varchar(30),
		PharmacyID int,
		constraint [PK_OperatorID] primary key clustered (ID),
		constraint [FK_Operator_PharmacyID] foreign key (PharmacyID) references Pharmacy(ID)
	)


