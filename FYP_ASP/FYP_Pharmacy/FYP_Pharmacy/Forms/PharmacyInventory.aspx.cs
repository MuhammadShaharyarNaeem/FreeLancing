using BLL.Pharmacy;
using Generics;
using Models.Pharmacy;
using System;
using System.Data;
using System.Reflection;
using System.Web.UI.WebControls;

namespace FYP_Pharmacy.Forms
{
    public partial class PharmacyInventory : PageActionHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region logging
            PageName = "PharmacyInventory";
            CONTEXT = "PharmacyInventory";
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

            lbl_title.Text = ((DataTable)Session[Enums.SessionName.UserDetails.ToString()]).Rows[0]["Company"].ToString();
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
            PharmacyInventoryHandler PharmacyInventoryHandler = new PharmacyInventoryHandler();
            PharmacyInventoryHandler.Insert(Model);
            MessageCollection.copyFrom(PharmacyInventoryHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                lbl_err.Text = "Record Inserted Successfully";
                lbl_err.Style.Add("color", "#FF008000");
            }

        }
        public void DoUpdateAction()
        {
            var Model = MapToObject();
            PharmacyInventoryHandler PharmacyInventoryHandler = new PharmacyInventoryHandler();
            PharmacyInventoryHandler.Update(Model);
            MessageCollection.copyFrom(PharmacyInventoryHandler.MessageCollection);

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
            PharmacyInventoryHandler PharmacyInventoryHandler = new PharmacyInventoryHandler();
            PharmacyInventoryHandler.Delete(Convert.ToInt32(txt_id.Text));
            MessageCollection.copyFrom(PharmacyInventoryHandler.MessageCollection);

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
            txt_qty.Text = string.Empty;
            ddl_Medicine.DataSource = null;
            ddl_Medicine.DataBind();
            
        }
        public void DisableControls()
        {
            txt_id.Enabled = false;
            txt_qty.Enabled = false;
            ddl_Medicine.Enabled = false;
            
        }
        public void EnableControls()
        {
            txt_qty.Enabled = true;
            ddl_Medicine.Enabled = true;
        }
        public void FillGrid()
        {
            PharmacyInventoryHandler PharmacyInventoryHandler = new PharmacyInventoryHandler();
            PharmacyInventoryHandler.DoFillGridAction();
            DataTable gridData = PharmacyInventoryHandler.dt;
            MessageCollection.copyFrom(PharmacyInventoryHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }

            gridView.DataSource = gridData;
            gridView.DataBind();

        }
        public void FillFields(int ID)
        {
            PharmacyInventoryHandler PharmacyInventoryHandler = new PharmacyInventoryHandler();
            PharmacyInventoryHandler.DoFillBackPanelAction(ID);
            DataTable Data = PharmacyInventoryHandler.dt;
            MessageCollection.copyFrom(PharmacyInventoryHandler.MessageCollection);

            if (MessageCollection.isErrorOccured)
            {
                MessageCollection.PublishLog();
                lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                lbl_err.Visible = true;
            }
            else
            {
                txt_id.Text = Data.Rows[0]["ID"].ToString();
                ddl_Medicine.SelectedValue = Data.Rows[0]["MedicineID"].ToString();
                txt_qty.Text = Data.Rows[0]["Quantity"].ToString();
            }
        }
        public PharmacyInventoryModel MapToObject()
        {
            return new PharmacyInventoryModel()
            {
                Quantity=Convert.ToInt32(txt_qty.Text),
                MedicineID = Convert.ToInt32(ddl_Medicine.SelectedValue.ToString()),
                PharmacyID = Convert.ToInt32(((DataTable)Session[Enums.SessionName.UserDetails.ToString()]).Rows[0]["PharmacyID"].ToString()),
                ID = string.IsNullOrWhiteSpace(txt_id.Text) ? 0 : Convert.ToInt32(txt_id.Text)
            };
        }
        #endregion

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);
            
            int ID = int.Parse(gridView.DataKeys[rowIndex].Value.ToString());
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