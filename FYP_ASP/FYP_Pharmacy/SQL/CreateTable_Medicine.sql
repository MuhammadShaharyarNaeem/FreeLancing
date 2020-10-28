use [PharmaMS]
go

if not exists (select * from sysobjects where name='Medicine')
	CREATE TABLE Medicine(
		ID int not null identity,
		Name varchar(30),
		QRCode varchar(250),
		ExpiryDate datetime,
		MfgDate datetime,
		Quantity int,
		BatchNo int,
		RegistrationNbr int,
		Registrant varchar(30),
		Price float,
		constraint [PK_MedicineID] primary key clustered (ID)
	)
