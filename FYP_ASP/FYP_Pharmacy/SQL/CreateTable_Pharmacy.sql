use [PharmaMS]
go

if not exists (select * from sysobjects where name='Pharmacy')
	create table Pharmacy(
		ID int not null identity,
		Name varchar(30),
		Email varchar(30),
		ContactNumber varchar(30),
		Description varchar(30),
		Address varchar(150),
		RegistrationNumber varchar(100),
		Constraint [PK_PharmacyID] primary key clustered (id)
	)