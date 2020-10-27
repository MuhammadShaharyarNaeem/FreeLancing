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
                        " select top 1 * " +
                        " from users with(nolock) " +
                        " where loginname = @arg0 and password = @arg1 ";

                case "GetMedicineData":
                    return
                        "select Name,batch_no,MfgDate,ExpiryDate,RegistrationNbr,Registrant,Price from medicine m where QRCode = @arg0";
                case "GetUsers":
                    return
                        " select loginname as [Login],accesslevel as [AccessLevel],operator.name as [OperatorName],operator.email as [OperatorEmail]," +
                        " Pharmacy.name as [PharmacyName] " +
                        " from users " +
                        " inner join operator on operator.ID = users.OperatorID " +
                        " inner join Pharmacy on pharmacy.id = operator.pharmacyid ";
                default:
                    return "";
            }
        }
    }
}
