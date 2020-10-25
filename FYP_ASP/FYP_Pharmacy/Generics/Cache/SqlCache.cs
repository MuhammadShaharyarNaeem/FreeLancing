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
                default:
                    return "";
            }
        }
    }
}
