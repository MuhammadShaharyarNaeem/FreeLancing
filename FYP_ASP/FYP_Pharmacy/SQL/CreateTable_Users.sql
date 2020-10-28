use PharmaMS
go 

if not exists (select * from sysobjects where name='Users')
	Create Table Users
	(
		ID int not null identity,
		LoginName varchar(30),
		Password varchar(30),
		AccessLevel int,
		PharmaCompanyID int,
		OperatorID int,
		constraint [PK_UserID] primary key clustered (ID),
		constraint [FK_Users_PharmaCompanyID] foreign key (PharmaCompanyID) references PharmaCompany(ID),
		constraint [FK_Users_OperatorID] foreign key (OperatorID) references Pharmacy(ID)
	)


	