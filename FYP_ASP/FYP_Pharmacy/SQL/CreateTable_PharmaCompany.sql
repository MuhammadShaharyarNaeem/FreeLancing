use [PharmaMS]
go

if not exists (select * from sysobjects where name='PharmaCompany')
	create table PharmaCompany(
		ID int not null,
		Name varchar(30),
		Email varchar(30),
		ContactNumber varchar(30),
		Description varchar(30),
		Address varchar(150),
		Constraint [PK_PharmaCompanyID] primary key clustered (id)
	)