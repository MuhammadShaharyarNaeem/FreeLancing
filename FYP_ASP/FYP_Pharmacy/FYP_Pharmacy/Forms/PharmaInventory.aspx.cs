using BLL.PharmacyInventory;
using Generics;
using System;
using System.Reflection;

namespace FYP_Pharmacy.Forms
{
    public partial class PharmaInventory : PageActionHandler
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session == null || Session[Generics.Enums.SessionName.AccountSetup.ToString()] == null)
                {
                    Response.Redirect("login.aspx");
                }
            }
            getMedData();
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
                LogType = Generics.Enums.LogType.Functional,
                Function = method.Name
            });
            string qrcode = medicineQRcode.Text;
            PharmacyInventory_Handler piHandler = new PharmacyInventory_Handler();
            piHandler.qr_code = qrcode;
            piHandler.DoAction();
            var medicine = piHandler.GetData();
            this.MessageCollection.copyFrom(piHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                gridPharmacy.DataSource = medicine;
                gridPharmacy.DataBind();
                gridPharmacy.Visible = true;
            }
        }
    }
}