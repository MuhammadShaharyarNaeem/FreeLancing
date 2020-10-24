using System.Configuration;

namespace Generics
{
    public class SQLHandler
    {
        public static readonly string SQL_CONNECTION= ConfigurationManager.AppSettings["myConnectionString"].ToString();
        
    }
}
