namespace Generics.Cache
{
    public static class SqlCache
    {
        public static string GetSql(string queryName)
        {
            switch (queryName)
            {
                case "UserLogin":
                    return
                        " select users.ID as [ID],LoginName as [LoginName],Password as [Password], " +
                        " PharmaCompany.Name [Company], PharmaCompany.ID as [CompanyID], Pharmacy.Name as [Pharmacy], Pharmacy.ID as [PharmacyID], accessLevel as [AccessLevel] " +
                        " from users with (nolock) " +
                        " left join PharmaCompany with (nolock) on PharmaCompany.ID = users.PharmaCompanyID " +
                        " left join pharmacy with (nolock) on Users.PharmacyID = pharmacy.ID " +
                        " where users.LoginName = @arg0 and users.Password = @arg1";
                case "GetMedicineData":
                    return
                        "select Name,batch_no,MfgDate,ExpiryDate,RegistrationNbr,Registrant,Price from medicine m where QRCode = @arg0";
                #region Users
                case "GetUsers":
                    return
                        " select users.id as [ID], loginname as [Name],accesslevel as [AccessLevel], " +
                        " case when PharmacyID !=null then pharmacy.name else pharmacompany.name end as [Company] " +
                        " from users with(nolock) " +
                        " left join PharmaCompany with(nolock) on PharmaCompany.ID = PharmaCompanyID " +
                        " left join pharmacy with(nolock) on Pharmacy.ID = PharmacyID ";
                case "GetUser":
                    return
                        " select users.id as [ID], loginname as [Name],accesslevel as [AccessLevel], password as [Password]," +
                        " case when PharmacyID !=null then PharmacyID else PharmaCompanyID end as [Company]," +
                        " users.name as [UserName], users.contactnumber as [contactnumber], users.email as [email] " +
                        " from users with(nolock) " +
                        " left join PharmaCompany with(nolock) on PharmaCompany.ID = PharmaCompanyID " +
                        " left join pharmacy with(nolock) on Pharmacy.ID = PharmacyID " +
                        " where users.id = @arg0";
                case "InsertUser":
                    return
                        "insert into users(LoginName,Password,AccessLevel,PharmaCompanyID,PharmacyID,Name,Email,ContactNumber) values(@arg0 ,@arg1 ,@arg2 ,@arg3 ,@arg4, @arg5, @arg6, @arg7) ";
                case "UpdateUser":
                    return
                        "update users set LoginName=@arg0, Password=@arg1, AccessLevel=@arg2, PharmaCompanyID=@arg3, PharmacyID= @arg4,Name=@arg6,Email=@arg7,ContactNumber=@arg8 where id = @arg5 ";
                case "DeleteUser":
                    return
                        "delete from users where id= @arg0";
                case "GetUserPharmaCompany":
                    return "select ID,Name from PharmaCompany";
                case "GetUserPharmacy":
                    return "select ID,Name from Pharmacy";
                #endregion
                #region PharmaCompany
                case "GetPharmaCompanys":
                    return
                        "select ID,Name,Email,ContactNumber,Description from PharmaCompany with (nolock)";
                case "GetPharmaCompany":
                    return
                        "select ID,Name,Email,ContactNumber,Description,Address from PharmaCompany with (nolock) where ID=@arg0";
                case "InsertPharmaCompany":
                    return
                        "insert into pharmaCompany(Name,Email,ContactNumber,Description,Address) values (@arg0,@arg1,@arg2,@arg3,@arg4)";
                case "UpdatePharmaCompany":
                    return
                        "update pharmacompany set Name = @arg0, Email=@arg1, ContactNumber=@arg2, Description=@arg3, Address=@arg4 where id = @arg5";
                case "DeletePharmaCompany":
                    return
                        "delete from pharmacompany where id = @arg0";
                #endregion
                #region Pharmacy
                case "GetPharmacys":
                    return
                        "select ID,Name,Email,ContactNumber,Description,Address from Pharmacy with (nolock)";
                case "GetPharmacy":
                    return
                        "select ID,Name,Email,ContactNumber,Description,Address from Pharmacy with (nolock) where ID=@arg0";
                case "InsertPharmacy":
                    return
                        "insert into Pharmacy(Name,Email,ContactNumber,Description,Address,RegistrationNumber) values (@arg0,@arg1,@arg2,@arg3,@arg4,@arg5)";
                case "UpdatePharmacy":
                    return
                        "update Pharmacy set Name = @arg0, Email=@arg1, ContactNumber=@arg2, Description=@arg3, Address=@arg4 where id = @arg5";
                case "DeletePharmacy":
                    return
                        "delete from Pharmacy where id = @arg0";
                #endregion
                #region Medicine
                case "GetMedicines":
                    return
                        "select ID,Name,convert(varchar, ExpiryDate, 101) as [ExpiryDate], convert(varchar, MfgDate, 101) as [MfgDate],BatchNo,Price from Medicine with (nolock)";
                case "GetMedicine":
                    return
                        "select ID,Name,QRCode,convert(varchar, ExpiryDate, 101) as [ExpiryDate],convert(varchar, MfgDate, 101) as [MfgDate],BatchNo,Price from Medicine with (nolock) where ID=@arg0";
                case "InsertMedicine":
                    return
                        "insert into Medicine(Name,QRCode,ExpiryDate,MfgDate,BatchNo,Price,PharmaCompanyID) values (@arg0,@arg1,@arg2,@arg3,@arg4,@arg5,@arg6)";
                case "UpdateMedicine":
                    return
                        "update Medicine set Name=@arg0, QRCode=@arg1, ExpiryDate=@arg2, MfgDate=@arg3, BatchNo=@arg4,  Price =@arg5 where id = @arg6";
                case "DeleteMedicine":
                    return
                        "delete from Medicine where id = @arg0";
                #endregion
                #region PharmacyInventory
                case "GetPharmacyInventory":
                    return
                        " select PharmacyInventory.ID,Medicine.Name,Medicine.BatchNo,Medicine.Price,PharmacyInventory.Quantity  " +
                        " from PharmacyInventory with (nolock) " +
                        " inner join Medicine with (nolock) on Medicine.ID = PharmacyInventory.MedicineID " +
                        " where PharmacyID = @arg0 ";
                case "GetPharmacyInventoryByID":
                    return
                        " select PharmacyInventory.ID as [ID], Medicine.ID as [MedicineID], Medicine.Name as [MedicineName], Quantity " +
                        " from PharmacyInventory with (nolock) " +
                        " inner join Medicine with (nolock) on Medicine.ID = PharmacyInventory.MedicineID " +
                        " where PharmacyInventory.id = @arg0";
                case "InsertPharmacyInventory":
                    return
                        " insert into PharmacyInventory (MedicineID,PharmacyID,Quantity) values (@arg0,@arg1,@arg2)";
                case "UpdatePharmacyInventory":
                    return
                        " update PharmacyInventory set MedicineID = @arg0, Quantity = @arg1 where id = @arg2";
                case "DeletePharmacyInventory":
                    return
                        " delete from PharmacyInventory where id = @arg0";
                case "GetPharmacyMedicine":
                    return
                        " select ID,Name + '-' + BatchNo as [Name] " +
                        " from medicine " +
                        " where ExpiryDate >= GetDate()";
                #endregion
                #region PharmacyPOS
                case "GetPOSMedicine":
                        return
                        " select PharmacyInventory.ID ,Name,convert(varchar, ExpiryDate, 101) as [ExpiryDate], convert(varchar, MfgDate, 101) as [MfgDate],BatchNo,Price,Quantity,medicine.qrcode as [QRCode] " +
                        " from medicine with(nolock) " +
                        " left join PharmacyInventory on PharmacyInventory.MedicineID = medicine.id " +
                        " where PharmacyID = @arg0 and QRCode = @arg1 ";
                #endregion
                default:
                    return "";
            }
        }
    }
}
