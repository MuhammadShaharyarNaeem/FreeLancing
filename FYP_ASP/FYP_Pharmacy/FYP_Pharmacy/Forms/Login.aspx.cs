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
                LogType = Enums.LogType.Functional,
                Function = method.Name
            });
            if (!string.IsNullOrWhiteSpace(txt_login.Text) || !string.IsNullOrWhiteSpace(txt_password.Text))
            {
                LoginHandler login = new LoginHandler(txt_login.Text.ToLower(), txt_password.Text, Session);
                login.DoAction();
                MessageCollection.copyFrom(login.MessageCollection);
                int accessLevel = login.accessLevel;
                if (MessageCollection.isErrorOccured)
                {
                    MessageCollection.PublishLog();
                    lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                    lbl_err.Visible = true;
                }
                else
                {
                    switch (accessLevel)
                    {
                        case (int)Enums.AccessLevel.Admin:
                            {
                                Response.Redirect("Users.aspx");
                                break;
                            }
                        case (int)Enums.AccessLevel.CompanyAdmin:
                            {
                                Response.Redirect("Medicine.aspx");
                                break;
                            }
                        case (int)Enums.AccessLevel.PharmacyAdmin:
                            {
                                Response.Redirect("PharmacyInventory.aspx");
                                break;
                            }
                        case (int)Enums.AccessLevel.Operator:
                            {
                                Response.Redirect("PharmacyPOS.aspx");
                                break;
                            }
                    }
                    


                    
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