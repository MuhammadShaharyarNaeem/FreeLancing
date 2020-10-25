using Generics;
using System.Collections;

namespace BLL.Login
{
    public class UserLogin : ActionHandler
    {
        string userName, password;
        public UserLogin(string UserName, string Password)
        {
            userName = UserName;
            password = Password;
        }

        public override void DoAction()
        {
            ArrayList Param = new ArrayList()
            {
                userName,
                password
            };

        }
    }
}
