using Generics;
using Generics.Cache;
using System.Collections;
using System.Web.SessionState;

namespace BLL.Login
{
    public class LoginHandler : ActionHandler
    {
        #region Fields & Properties
        string userName, password;
        HttpSessionState Session;
        public string accessLevel { get; set; }
        #endregion

        public LoginHandler(string UserName, string Password, HttpSessionState session)
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
                    Session[Enum.SessionName.UserDetails.ToString()] = dt;
                    accessLevel = dt.Rows[0]["accesslevel"].ToString();
                }
            }
        }
    }
}
