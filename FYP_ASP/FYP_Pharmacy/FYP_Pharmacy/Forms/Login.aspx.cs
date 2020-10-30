using BLL.Login;
using Generics;
using System;
using System.Reflection;

namespace FYP_Pharmacy.Forms
{
    public partial class Login : PageActionHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region logging
            PageName = "Login";
            CONTEXT = "Login";
            method = MethodBase.GetCurrentMethod();
            MessageCollection.addMessage(new Message()
            {
                Context = CONTEXT,
                ErrorCode = 0,
                isError = false,
                WebPage = PageName,
                LogType = Generics.Enums.LogType.Functional,
                Function = method.Name
            });
            #endregion
        }

        protected void OnSubmit_Click(object sender, EventArgs e)
        {
            method = MethodBase.GetCurrentMethod();
            MessageCollection.addMessage(new Message()
            {
                Context = CONTEXT,
                ErrorCode = 0,
                isError = false,
                WebPage = PageName,
                LogType = Generics.Enums.LogType.Functional,
                Function = method.Name
            });
            if (!string.IsNullOrWhiteSpace(txt_login.Text) || !string.IsNullOrWhiteSpace(txt_password.Text))
            {
                LoginHandler login = new LoginHandler(txt_login.Text, txt_password.Text, Session);
                login.DoAction();
                MessageCollection.copyFrom(login.MessageCollection);
                string accessLevel = login.accessLevel;
                if (MessageCollection.isErrorOccured)
                {
                    MessageCollection.PublishLog();
                    lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                    lbl_err.Visible = true;
                }
                else
                {
                    if (Convert.ToInt32(accessLevel) == 1001)
                        Response.Redirect("Users.aspx");
                    else
                        Response.Redirect("PharmaInventory");
                }
            }
            else
            {
                lbl_err.Text = "LoginName and Password cannot be empty";
                lbl_err.Visible = true;
            }

        }
    }
}