using Generics;
using Generics.Cache;
using System.Data;

namespace BLL.Users
{
    public class UsersHandler : ActionHandler
    {
        public DataTable dt;
        public override void DoAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetUsers"));
            MessageCollection.copyFrom(sql.Messages);
            
            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "UsersHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType=Enum.LogType.Exception,
                    WebPage="Users"
                });
            }
        }
    }
}
