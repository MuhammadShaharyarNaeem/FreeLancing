using System;
using System.Data;
using System.Web.UI;

namespace FYP_Pharmacy
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session != null)
            {
                DataTable dt = (DataTable)Session[Generics.Enums.SessionName.UserDetails.ToString()];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (!string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) && dt.Rows[0]["accesslevel"].ToString() == "1001")
                    {
                        medPage.Visible = false;
                        pharmacompanypage.Visible = true;
                        pharmacypage.Visible = true;
                        userspage.Visible = true;
                        pharmaInventory.Visible = true;
                        PosPage.Visible = true;
                        logoutbtn.Visible = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) && dt.Rows[0]["accesslevel"].ToString() == "1002")
                    {
                        medPage.Visible = true;
                        pharmacompanypage.Visible = false;
                        pharmacypage.Visible = false;
                        userspage.Visible = false;
                        pharmaInventory.Visible = false;
                        PosPage.Visible = false;
                        logoutbtn.Visible = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) && dt.Rows[0]["accesslevel"].ToString() == "1003")
                    {
                        medPage.Visible = false;
                        pharmacompanypage.Visible = false;
                        pharmacypage.Visible = false;
                        userspage.Visible = false;
                        pharmaInventory.Visible = true;
                        PosPage.Visible = true;
                        logoutbtn.Visible = true;
                    }
                    else if (!string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) && dt.Rows[0]["accesslevel"].ToString() == "1004")
                    {
                        medPage.Visible = false;
                        pharmacompanypage.Visible = false;
                        pharmacypage.Visible = true;
                        userspage.Visible = false;
                        pharmaInventory.Visible = false;
                        PosPage.Visible = true;
                        logoutbtn.Visible = true;
                    }
                }
            }

        }
    }
}