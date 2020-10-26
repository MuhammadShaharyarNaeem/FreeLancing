using System;
using System.Data;
using System.Reflection;
using Generics;
using BLL.Users;
using Generics.Cache;

namespace FYP_Pharmacy.Forms
{
    public partial class Users : PageActionHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region logging
            PageName = "Users";
            CONTEXT = "Users";
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

            if (!IsPostBack)
            {
                if (Session == null || Session[Generics.Enum.SessionName.UserDetails.ToString()] == null)
                {
                    DataTable dt = (DataTable)Session[Generics.Enum.SessionName.UserDetails.ToString()];
                    if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) || dt.Rows[0]["accesslevel"].ToString() != "1001")
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }

            FillUsersGrid();
        }
        protected void AddNew_Click(object sender, EventArgs e)
        {
            pnl_front.Visible = false;
        }

        public void FillUsersGrid()
        {
            UsersHandler usersHandler = new UsersHandler();
            usersHandler.DoAction();
            MessageCollection.copyFrom(usersHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                gridPharmacy.DataSource = usersHandler.dt;
            }

        }
    }
}