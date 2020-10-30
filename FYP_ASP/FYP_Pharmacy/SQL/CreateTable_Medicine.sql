use [PharmaMS]
go

if not exists (select * from sysobjects where name='Medicine')
	CREATE TABLE Medicine(
		ID int not null identity,
		Name varchar(30),
		QRCode varchar(250),
		ExpiryDate datetime,
		MfgDate datetime,
		BatchNo int,
		Price float,
		constraint [PK_MedicineID] primary key clustered (ID)
	)
