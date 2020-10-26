use [PharmaMS]
go

if not exists (select * from sysobjects where name='PurchaseDetails')
	create table PurchaseDetails(
		ID int not null,
		MedicineID int not null,
		Price float,
		PaymentDate datetime,
		Amount float,
		Constraint [PK_PurchaseDetailsID] primary key Clustered (ID),
		Constraint [FK_MedicineID] foreign key (MedicineID) references Medicine(ID)
		)