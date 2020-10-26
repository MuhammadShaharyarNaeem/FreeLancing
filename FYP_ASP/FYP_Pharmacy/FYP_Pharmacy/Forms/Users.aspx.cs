using System;
using System.Reflection;
using Generics;
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
        }
        protected void AddNew_Click(object sender, EventArgs e)
        {

        }
    }
}