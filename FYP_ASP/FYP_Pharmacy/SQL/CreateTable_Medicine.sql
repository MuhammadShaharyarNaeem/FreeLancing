use [PharmaMS]
go

if not exists (select * from sysobjects where name='Medicine')
	CREATE TABLE Medicine(
		ID int not null identity,
		Name varchar(30),
		QRCode varchar(250),
		ExpiryDate datetime,
		MfgDate datetime,
		BatchNo varchar(30),
		Price float,
		PharmaCompanyID int,
		constraint [PK_MedicineID] primary key clustered (ID),
		constraint [FK_Medicine_PharmaCompanyID] foreign key (PharmaCompanyID) references PharmaCompany(ID)
	)
