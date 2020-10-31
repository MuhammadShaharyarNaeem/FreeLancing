using Generics;
using System;

namespace FYP_Pharmacy
{
    public partial class _Default : PageActionHandler
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("Forms/login.aspx");
        }


    }
}