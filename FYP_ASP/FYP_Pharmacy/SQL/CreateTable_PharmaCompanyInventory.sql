use PharmaMS
go

if not exists (select * from sysobjects where name='PharmaCompanyInventory')
	create table PharmaCompanyInventory(
		ID int not null identity,
		MedicineID int not null,
		PharmaCompanyID int not null,
		Quantity int,
		Constraint [PK_PharmaCompanyInventoryID] primary key Clustered (ID),
		Constraint [FK_PharmaCompanyInventory_MedicineID] foreign key (MedicineID) references Medicine(ID),
		Constraint [FK_PharmaCompanyInventory_PharmaCompanyID] foreign key (PharmaCompanyID) references PharmaCompany(ID)
		)