use [PharmaMS]
go

if not exists (select * from sysobjects where name='CustomerPurchaseDetails')
	create table CustomerPurchaseDetails(
		ID int not null identity,
		MedicineID int not null,
		Price float,
		PaymentDate datetime,
		Amount float,
		CustomerID int,
		Constraint [PK_CustomerPurchaseDetailsID] primary key Clustered (ID),
		Constraint [FK_CustomerPurchaseDetails_MedicineID] foreign key (MedicineID) references Medicine(ID),
		Constraint [FK_CustomerPurchaseDetails_PharmacyID] foreign key (CustomerID) references Customer(ID)
		)