using Generics;
using Generics.Cache;
using System.Collections;
using System.Web.SessionState;

namespace BLL.Login
{
    public class UserLogin : ActionHandler
    {
        string userName, password;
        HttpSessionState Session;
        public UserLogin(string UserName, string Password, HttpSessionState session)
        {
            userName = UserName;
            password = Password;
            Session = session;
        }

        public override void DoAction()
        {
            ArrayList Params = new ArrayList()
            {
                userName,
                password
            };

            SQLHandler sql = new SQLHandler(Params);
            var dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("UserLogin"));

            MessageCollection.copyFrom(sql.Messages);
            if (!MessageCollection.isErrorOccured)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session[Enum.SessionName.AccountSetup.ToString()] = dt;
                }
            }
            else
                MessageCollection.PublishLog();
            
        }
    }
}
