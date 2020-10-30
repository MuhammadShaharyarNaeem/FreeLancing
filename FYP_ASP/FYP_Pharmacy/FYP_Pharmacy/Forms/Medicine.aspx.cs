using BLL.Medicine;
using Generics;
using Models.Medicine;
using System;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;

namespace FYP_Pharmacy.Forms
{
    public partial class Medicine : PageActionHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region logging
            PageName = "Medicine";
            CONTEXT = "Medicine";
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

            if (!IsPostBack)
            {
                if (Session == null || Session[Generics.Enums.SessionName.UserDetails.ToString()] == null)
                {
                    DataTable dt = (DataTable)Session[Generics.Enums.SessionName.UserDetails.ToString()];
                    if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) || dt.Rows[0]["accesslevel"].ToString() != "1001")
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }

            FillGrid();
        }
        #region Click Actions
        protected void AddNew_Click(object sender, EventArgs e)
        {
            pnl_front.Visible = false;
            pnl_back.Visible = true;
            btn_SaveUpdDel.Text = Enums.ButtonControl.Save.ToString();
            EmptyFields();
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            pnl_back.Visible = false;
            pnl_front.Visible = true;
            EmptyFields();
        }
        protected void btn_SaveUpdDel_Click(object sender, EventArgs e)
        {
            if (btn_SaveUpdDel.Text.Equals(Enums.ButtonControl.Save.ToString()))
            {
                DoSaveAction();
            }
            else if (btn_SaveUpdDel.Text.Equals(Enums.ButtonControl.Update.ToString()))
            {
                DoUpdateAction();
            }
            else if (btn_SaveUpdDel.Text.Equals(Enums.ButtonControl.Delete.ToString()))
            {
                DoDeleteAction();
            }
            pnl_back.Visible = false;
            pnl_front.Visible = true;
            EmptyFields();
            EnableControls();
            FillGrid();
        }
        #endregion

        #region DML Methods
        public void DoSaveAction()
        {
            var Model = MapToObject();
            MedicineHandler MedicineHandler = new MedicineHandler();
            MedicineHandler.Insert(Model);
            MessageCollection.copyFrom(MedicineHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                lbl_err.Text = "Record Inserted Successfully";
                lbl_err.ForeColor = System.Drawing.Color.Green;
            }

        }
        public void DoUpdateAction()
        {
            var Model = MapToObject();
            MedicineHandler MedicineHandler = new MedicineHandler();
            MedicineHandler.Update(Model);
            MessageCollection.copyFrom(MedicineHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                lbl_err.Text = "Record Updated Successfully";
                lbl_err.ForeColor = System.Drawing.Color.Green;
            }
        }
        public void DoDeleteAction()
        {
            MedicineHandler MedicineHandler = new MedicineHandler();
            MedicineHandler.Delete(Convert.ToInt32(txt_id.Text));
            MessageCollection.copyFrom(MedicineHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                lbl_err.Text = "Record Deleted Successfully";
                lbl_err.ForeColor = System.Drawing.Color.Green;
            }
        }
        #endregion

        #region HelperMethods
        public void EmptyFields()
        {
            txt_id.Text = string.Empty;
            txt_name.Text = string.Empty;
            txt_qrcode.Text = string.Empty;
            txt_exp.Text = string.Empty;
            txt_mfg.Text = string.Empty;
            txt_batch.Text = string.Empty;
            txt_reg.Text = string.Empty;
            txt_price.Text = string.Empty;
        }
        public void DisableControls()
        {
            txt_id.Enabled = false;
            txt_name.Enabled = false;
            txt_qrcode.Enabled = false;
            txt_exp.Enabled = false;
            txt_mfg.Enabled = false;
            txt_batch.Enabled = false;
            txt_reg.Enabled = false;
            txt_price.Enabled = false;
        }
        public void EnableControls()
        {
            txt_name.Enabled = true;
            txt_qrcode.Enabled = true;
            txt_exp.Enabled = true;
            txt_mfg.Enabled = true;
            txt_batch.Enabled = true;
            txt_reg.Enabled = true;
            txt_price.Enabled = true;
        }
        public void FillGrid()
        {
            MedicineHandler MedicineHandler = new MedicineHandler();
            MedicineHandler.DoFillGridAction();
            DataTable gridData = MedicineHandler.dt;
            MessageCollection.copyFrom(MedicineHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }

            gridPharmacy.DataSource = gridData;
            gridPharmacy.DataBind();


        }
        public void FillFields(int ID)
        {
            MedicineHandler MedicineHandler = new MedicineHandler();
            MedicineHandler.DoFillBackPanelAction(ID);
            DataTable Data = MedicineHandler.dt;
            MessageCollection.copyFrom(MedicineHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                txt_id.Text = Data.Rows[0]["ID"].ToString();
                txt_name.Text = Data.Rows[0]["Name"].ToString(); ;
                txt_qrcode.Text = Data.Rows[0]["QRCode"].ToString();
                txt_exp.Text = Data.Rows[0]["ExpiryDate"].ToString();
                txt_mfg.Text = Data.Rows[0]["MfgDate"].ToString();
                txt_batch.Text = Data.Rows[0]["BatchNo"].ToString();
                txt_reg.Text = Data.Rows[0]["RegistrationNbr"].ToString();
                txt_price.Text = Data.Rows[0]["Price"].ToString();
            }
        }
        public MedicineModel MapToObject()
        {
            return new MedicineModel()
            {

                Name = txt_name.Text,
                QRCode = txt_qrcode.Text,
                ExpiryDate = Convert.ToDateTime(txt_exp.Text),
                MfgDate = Convert.ToDateTime(txt_mfg.Text),
                BatchNo = txt_batch.Text,
                RegistrationNbr = txt_reg.Text,
                Price = Convert.ToInt64(txt_price.Text),
                ID = string.IsNullOrWhiteSpace(txt_id.Text) ? 0 : Convert.ToInt32(txt_id.Text)
            };
        }
        #endregion
        protected void gridPharmacy_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridPharmacy.Rows[rowIndex];
            int ID = int.Parse(row.Cells[0].Text);
            FillFields(ID);

            if (e.CommandName.Equals(Enums.GridCommand.EditRow.ToString()))
            {
                btn_SaveUpdDel.Text = Enums.ButtonControl.Update.ToString();
                EnableControls();
            }
            else if (e.CommandName.Equals(Enums.GridCommand.DeleteRow.ToString()))
            {
                btn_SaveUpdDel.Text = Enums.ButtonControl.Delete.ToString();
                DisableControls();
            }
            pnl_front.Visible = false;
            pnl_back.Visible = true;

        }
    }
}