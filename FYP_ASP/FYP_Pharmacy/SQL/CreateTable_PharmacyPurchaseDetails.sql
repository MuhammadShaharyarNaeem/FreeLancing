use [PharmaMS]
go

if not exists (select * from sysobjects where name='PharmacyPurchaseDetails')
	create table PharmacyPurchaseDetails(
		ID int not null identity,
		MedicineID int not null,
		Price float,
		PaymentDate datetime,
		Amount float,
		PharmacyID int,
		Constraint [PK_PharmacyPurchaseDetailsID] primary key Clustered (ID),
		Constraint [FK_PharmacyPurchaseDetails_MedicineID] foreign key (MedicineID) references Medicine(ID),
		Constraint [FK_PharmacyPurchaseDetails_PharmacyID] foreign key (PharmacyID) references Pharmacy(ID)
		)