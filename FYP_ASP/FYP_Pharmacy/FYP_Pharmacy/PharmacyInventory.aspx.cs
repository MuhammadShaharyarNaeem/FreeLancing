using BLL.PharmacyInventory;
using Generics;
using System;
using System.Reflection;
using System.Web.UI.WebControls;

namespace FYP_Pharmacy
{
    public partial class PharmacyInventory : PageActionHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gridPharmacy.Visible = false;
            }
            else
            {
                gridPharmacy.Visible = true;
                getMedData();
            }

        }

        protected void medicineQRcode_TextChanged(object sender, EventArgs e)
        {
            getMedData();
        }
        void getMedData()
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
            string qrcode = medicineQRcode.Text;
            PharmacyInventory_Handler piHandler = new PharmacyInventory_Handler();
            piHandler.qr_code = qrcode;
            piHandler.DoAction();
            var medicine = piHandler.GetData();

            gridPharmacy.DataSource = medicine;
            gridPharmacy.DataBind();
        }
    }
}