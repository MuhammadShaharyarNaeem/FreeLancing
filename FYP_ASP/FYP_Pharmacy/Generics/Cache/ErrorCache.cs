namespace Generics.Cache
{
    /*
     * General: 1000000
     * WebPage: 2000000    
     * Sql: 3000000
     */
    public static class ErrorCache
    {
        public const int noError = 0;
        private static readonly string noErrorString = "No Error";

        public const int GeneralSqlError = 2000000;
        private static readonly string GeneralSqlErrorString = "An Exception Occured while Executing Sql Statement";

        public const int SqlConnectionError = 2000001;
        private static readonly string SqlConnectionErrorString = "An Exception Occured while Opening Sql Connection";

        public const int RecordsNotFound = 2000002;
        private static readonly string RecordsNotFoundString = "No Records Found";

        public const int LoginFailed = 2000003;
        private static readonly string LoginFailedString = "Username or Password is incorrect";

        private static readonly string UnHandledErrorString = "UnHandled Error Occured";
        public static string getErrorMessage(int ErrorCode)
        {
            switch (ErrorCode)
            {
                case noError: return noErrorString;
                case GeneralSqlError: return GeneralSqlErrorString;
                case SqlConnectionError: return SqlConnectionErrorString;
                case RecordsNotFound: return RecordsNotFoundString;
                case LoginFailed: return LoginFailedString;
                default:
                    return UnHandledErrorString;
            }
        }

    }
}
