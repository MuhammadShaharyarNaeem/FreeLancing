use [PharmaMS]
go

if not exists (select * from sysobjects where name='Pharmacy')
	create table Pharmacy(
	ID int not null identity,
	RegistrationID int not null,
	Name varchar(30),
	Constraint [PK_PharmacyID] primary key clustered (ID)
	)