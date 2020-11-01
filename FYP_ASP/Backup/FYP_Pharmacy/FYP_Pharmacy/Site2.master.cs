using System;
using System.IO;

public partial class Site2 : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (IsPostBack != true)
        //{

        if (CheckSessions())
        {


            if (Convert.ToString(Session["User_Type"]) == "User")
            {

            }


        }
        else
        {

            ClearSessions();

        }
        //}

        //ClearSessions();

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
    }
    protected void lbtnDashboard_Click(object sender, EventArgs e)
    {
        Response.Redirect(Session["DashboardURL"] as string);
    }
    protected void lbtnProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("User_Profile.aspx");
    }
    protected void lbtnLogout_Click(object sender, EventArgs e)
    {
        ClearSessions();
        string PageName = Path.GetFileName(Request.Path);
        Response.Redirect(PageName);
    }

}
