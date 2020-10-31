using System;

public partial class Master_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {

        }
    }

    protected void lbtnLogout_Click(object sender, EventArgs e)
    {

    }
    private void PushNotifications()
    {
        //message notification              
    }
    private Boolean CheckSessions()
    {
        if (Session["User_ID"] != null)
        {
            if (Session["User_Type"] != null)
            {
                if (Session["Email"] != null)
                {
                    if (Session["DashboardURL"] != null)
                    {
                        if (Session["User_Name"] != null)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
    public void ClearSessions()
    {
        Session["User_ID"] = null;
        Session["User_Name"] = null;
        Session["Email"] = null;
        Session["DashboardURL"] = null;
        Session["User_Type"] = null;
    }
}
