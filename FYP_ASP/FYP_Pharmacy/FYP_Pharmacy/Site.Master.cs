using System;
using System.Data;
using System.Web.UI;

namespace FYP_Pharmacy
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session != null || Session[Generics.Enums.SessionName.UserDetails.ToString()] != null)
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    DataTable dt = (DataTable)Session[Generics.Enums.SessionName.UserDetails.ToString()];
                    if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) || dt.Rows[0]["accesslevel"].ToString() == "1001")
                    {
                        medPage.Visible = true;
                        pharmacompanypage.Visible = true;
                        pharmacypage.Visible = true;
                        userspage.Visible = true;
                    }
                    else if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) || dt.Rows[0]["accesslevel"].ToString() == "1002")
                    {
                        medPage.Visible = false;
                        pharmacompanypage.Visible = false;
                        pharmacypage.Visible = false;
                        userspage.Visible = false;
                    }
                    else if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) || dt.Rows[0]["accesslevel"].ToString() == "1003")
                    {
                        medPage.Visible = false;
                        pharmacompanypage.Visible = false;
                        pharmacypage.Visible = false;
                        userspage.Visible = false;
                    }
                }
            }
        }
    }
}