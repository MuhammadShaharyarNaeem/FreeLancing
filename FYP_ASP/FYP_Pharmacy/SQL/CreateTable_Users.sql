use PharmaMS
go 

if not exists (select * from sysobjects where name='Users')
	Create Table Users
	(
		ID int not null identity,
		LoginName varchar(30),
		Password varchar(30),
		AccessLevel int,
		OperatorID int null,
		constraint [PK_UserID] primary key clustered (ID),
		constraint [FK_OperatorID] foreign key (OperatorID) references Operator(ID)
	)


	