use PharmaMS
go

if not exists (select * from sysobjects where name='PharmacyInventory')
	create table PharmacyInventory(
		ID int not null identity,
		MedicineID int not null,
		PharmacyID int not null,
		Quantity int,
		Constraint [PK_PharmacyInventory] primary key Clustered (ID),
		Constraint [FK_PharmacyInventory_MedicineID] foreign key (MedicineID) references Medicine(ID),
		Constraint [FK_PharmacyInventory_PharmaCompanyID] foreign key (PharmacyID) references Pharmacy(ID)
		)