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
                        " PharmaCompany.Name [Company], Pharmacy.Name as [Pharmacy], accessLevel as [AccessLevel] " +
                        " from users with (nolock) " +
                        " left join PharmaCompany with (nolock) on PharmaCompany.ID = users.PharmaCompanyID " +
                        " left join Operator with (nolock) on Operator.ID = users.OperatorID " +
                        " left join pharmacy with (nolock) on Operator.PharmacyID = pharmacy.ID " +
                        " where users.LoginName = @arg0 and users.Password = @arg1";
                case "GetMedicineData":
                    return
                        "select Name,batch_no,MfgDate,ExpiryDate,RegistrationNbr,Registrant,Price from medicine m where QRCode = @arg0";
                #region Users
                case "GetUsers":
                    return
                        " select users.id as [ID], loginname as [Name],accesslevel as [AccessLevel], " +
                        " case when PharmacyID !=null then PharmacyID else PharmaCompanyID end as [Company] " +
                        " from users with(nolock) " +
                        " left join PharmaCompany with(nolock) on PharmaCompany.ID = PharmaCompanyID " +
                        " left join Operator with(nolock) on Operator.ID = OperatorID " +
                        " left join pharmacy with(nolock) on Pharmacy.ID = Operator.PharmacyID ";
                case "GetUser":
                    return
                        " select users.id as [ID], loginname as [Name],accesslevel as [AccessLevel], password as [Password]," +
                        " case when PharmacyID !=null then PharmacyID else PharmaCompanyID end as [Company] " +
                        " from users with(nolock) " +
                        " left join PharmaCompany with(nolock) on PharmaCompany.ID = PharmaCompanyID " +
                        " left join Operator with(nolock) on Operator.ID = OperatorID " +
                        " left join pharmacy with(nolock) on Pharmacy.ID = Operator.PharmacyID " +
                        " where users.id = @arg0";
                case "InsertUser":
                    return
                        "insert into users(LoginName,Password,AccessLevel,PharmaCompanyID,OperatorID) values(@arg0 ,@arg1 ,@arg2 ,@arg3 ,@arg4) ";
                case "UpdateUser":
                    return
                        "update users set LoginName=@arg0, Password=@arg1, AccessLevel=@arg2, PharmaCompanyID=@arg3, OperatorID= @arg4 where id = @arg5 ";
                case "DeleteUser":
                    return
                        "delete from users where id= @arg0";
                case "GetCompany":
                    return "select ID,Name from PharmaCompany";
                case "GetPharmacy":
                    return "select ID,Name from Pharmacy";
                #endregion
                #region PharmaCompany
                case "GetPharmaCompanys":
                    return
                        "select ID,Name,Email,ContactNumber,Description,Address from PharmaCompany with (nolock)";
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
                default:
                    return "";
            }
        }
    }
}
