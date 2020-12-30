namespace EmailingProject.Generics.Cache
{
    public static class SqlCache
    {
        public static string GetSql(string queryName)
        {
            switch (queryName)
            {
                case "InsertMail":
                    return "insert into Mails(userid,emailto,hours,token,isused) values (@arg0,@arg1,@arg2,@arg3,@arg4)";
                case "CheckToken":
                    return "select isused from mails where token = @arg0";
                case "UpdateToken":
                    return "update Mails set isUsed = 1 and EmailFrom = @arg1 where token = @arg0";
                default:
                    return "";
            }
        }
    }
}
