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
                LogType = Generics.Enum.LogType.Functional,
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
                LogType = Generics.Enum.LogType.Functional,
                Function = method.Name
            });

            UserLogin login = new UserLogin(txt_login.Text, txt_password.Text, Session);
            login.DoAction();
            MessageCollection.copyFrom(login.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                Response.Redirect("PharmacyInventory.aspx");
            }
        }
    }
}