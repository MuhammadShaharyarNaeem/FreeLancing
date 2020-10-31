using BLL.Pharmacy;
using Generics;
using Models.Pharmacy;
using System;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;
using BLL.Medicine;
using System.Linq;

namespace FYP_Pharmacy.Forms
{
    public partial class PharmacyPOS : PageActionHandler
    {
        private DataTable gridDt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region logging
            PageName = "PharmacyPOS";
            CONTEXT = "PharmacyPOS";
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

            DataTable dt = ((DataTable)Session[Enums.SessionName.POSdetail.ToString()]);
            FillGrid();
        }

        public void FillGrid()
        {
            if (Session[Enums.SessionName.POSdetail.ToString()] != null)
            {
                gridDt = Session[Enums.SessionName.POSdetail.ToString()] as DataTable;
                gridView.DataSource = gridDt;
                gridView.Columns[3].FooterStyle.CssClass = "form-label";
                gridView.Columns[3].FooterText = gridDt.AsEnumerable().Select(x => x.Field<double>("price")).Sum().ToString();
                gridView.DataBind();
            }
            else
            {
                lbl_err.Text = "Please scan medicine to add in bill";
                lbl_err.Visible = true;
            }

        }

        protected void qrcode_TextChanged(object sender, EventArgs e)
        {
            MedicineHandler medicineHandler = new MedicineHandler();
            int PharmacyID = Convert.ToInt32(((DataTable)Session[Enums.SessionName.UserDetails.ToString()]).Rows[0]["PharmacyID"].ToString());
            if (Session != null && Session[Enums.SessionName.POSdetail.ToString()] != null)
                medicineHandler.GetMedicineAgainstQRCode(qrcodebox.Text, Session[Enums.SessionName.POSdetail.ToString()] as DataTable,PharmacyID);
            else
                medicineHandler.GetMedicineAgainstQRCode(qrcodebox.Text, new DataTable(), PharmacyID);
            Session[Enums.SessionName.POSdetail.ToString()]= medicineHandler.dt;
            
            gridDt = medicineHandler.dt;
        }
    }
}