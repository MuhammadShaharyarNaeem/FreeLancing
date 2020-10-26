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
                        " select users.id, Pharmacy.Name " +
                        " from users with(nolock) " +
                        " inner join Pharmacy with(nolock) on Pharmacy.id = users.Pharmacyid " +
                        " where loginname = @arg0 and password = @arg1 ";

                case "GetMedicineData":
                    return
                        "select Name,batch_no,MfgDate,ExpiryDate,RegistrationNbr,Registrant,Price from medicine m where QRCode = @arg0";
                default:
                    return "";
            }
        }
    }
}
