using Generics;
using Generics.Cache;
using System;
using System.Collections;
using System.Data;
using System.Web.SessionState;

namespace BLL.Login
{
    public class LoginHandler : ActionHandler<object>
    {
        #region Fields & Properties
        string userName, password;
        HttpSessionState Session;
        public DataTable dt = new DataTable();
        public int accessLevel { get; set; }
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
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("UserLogin"));

            MessageCollection.copyFrom(sql.Messages);
            if (!MessageCollection.isErrorOccured)
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    Session[Enums.SessionName.UserDetails.ToString()] = dt;
                    accessLevel = Convert.ToInt16(dt.Rows[0]["accesslevel"].ToString());
                }
                else if (dt == null || dt.Rows.Count <= 0)
                {
                    MessageCollection.addMessage(new Message()
                    {
                        Context = "LoginHandler",
                        ErrorCode = ErrorCache.LoginFailed,
                        ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.LoginFailed),
                        isError = true,
                        LogType = Enums.LogType.Exception,
                        WebPage = "Login"
                    });
                }
            }
        }

        public override void DoFillGridAction()
        {
            throw new System.NotImplementedException();
        }

        public override void DoFillBackPanelAction(int ID)
        {
            throw new System.NotImplementedException();
        }

        public override void Insert(object Model)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(object Model)
        {
            throw new System.NotImplementedException();
        }

        public override void Delete(int ID)
        {
            throw new System.NotImplementedException();
        }
    }
}
