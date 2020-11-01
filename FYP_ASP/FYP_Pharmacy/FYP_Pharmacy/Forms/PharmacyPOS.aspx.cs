using Generics;
using System;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using BLL.Pharmacy;
using Models.Pharmacy;
using Generics.Cache;

namespace FYP_Pharmacy.Forms
{
    public partial class PharmacyPOS : PageActionHandler
    {
        Dictionary<string, int> medQuantity = new Dictionary<string, int>();
        public string PharmacyID { get; set; }
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

            if (Session != null)
            {
                DataTable dt = (DataTable)Session[Enums.SessionName.UserDetails.ToString()];
                if (dt != null && dt.Rows.Count > 0)
                {
                    if (string.IsNullOrWhiteSpace(dt.Rows[0]["accesslevel"].ToString()) ||
                        (Convert.ToInt32(dt.Rows[0]["accesslevel"].ToString()) != (int)Enums.AccessLevel.PharmacyAdmin &&
                        Convert.ToInt32(dt.Rows[0]["accesslevel"].ToString()) != (int)Enums.AccessLevel.Operator))
                    {
                        Response.Redirect("login.aspx");
                    }
                    else
                    {
                        lbl_title.Text = dt.Rows[0]["Pharmacy"].ToString();
                    }
                }
                else
                {
                    Response.Redirect("login.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }

            txt_qrode.Text = "";
            txt_qrode.Focus();

        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int ID = int.Parse(gridView.DataKeys[rowIndex].Value.ToString());

            if (e.CommandName.Equals(Enums.GridCommand.DeleteRow.ToString()))
            {
                DataTable dt = (DataTable)Session[Enums.SessionName.POSdetail.ToString()];
                dt.AsEnumerable().Where(r => r.Field<int>("ID") == ID).ToList().ForEach(row => row.Delete());
                dt.AcceptChanges();
                gridView.DataSource = dt;
                gridView.DataBind();
                CalculateSum(dt);
            }
        }

        private void CalculateSum(DataTable dt)
        {
            int sum = 0;
            foreach (DataRow row in dt.Rows)
            {
                sum = sum + Convert.ToInt32(row["Price"].ToString());
            }
            txt_total.Text = sum.ToString();
        }

        protected void txt_qrode_TextChanged(object sender, EventArgs e)
        {
            var model = MapModelForQRCode();
            PharmacyPOSHandler handler = new PharmacyPOSHandler();
            var dt = handler.GetMedicine(model);
            MessageCollection.copyFrom(handler.MessageCollection);

            if (!MessageCollection.isErrorOccured)
            {
                if (ViewState != null && ViewState[Enums.SessionName.POSdetail.ToString()] != null && 
                    ViewState[Enums.SessionName.MedicineDetail.ToString()] != null)
                {
                    DataRow ValueRow = dt.Rows[0];
                    string qrCode = ValueRow["QRCode"].ToString();
                    if (medQuantity.ContainsKey(qrCode))
                    {
                        if (medQuantity[qrCode] == 0)
                        {
                            MessageCollection.addMessage(new Message()
                            {
                                Context = "PharmacyPOS",
                                LogType = Enums.LogType.Exception,
                                WebPage = "PharmacyPOS",
                                isError = true,
                                ErrorCode = ErrorCache.NoQuantityLeftError,
                                ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.NoQuantityLeftError)
                            });

                            MessageCollection.PublishLog();
                            lbl_err.Text = MessageCollection.Messages[MessageCollection.Messages.Count - 1].ErrorMessage;
                            lbl_err.Visible = true;
                        }
                        else
                        {
                            medQuantity[qrCode] = medQuantity[qrCode] - 1;
                        }
                    }
                    else
                    {
                        medQuantity.Add(qrCode, Convert.ToInt32(ValueRow["Quantity"]));
                    }

                    if (!MessageCollection.isErrorOccured)
                    {
                        DataTable POSdt = (DataTable)ViewState[Enums.SessionName.POSdetail.ToString()];
                        DataRow dr = POSdt.NewRow();

                        dr["ID"] = ValueRow["ID"];
                        dr["Name"] = ValueRow["Name"];
                        dr["BatchNo"] = ValueRow["BatchNo"];
                        dr["ExpiryDate"] = ValueRow["ExpiryDate"];
                        dr["MfgDate"] = ValueRow["MfgDate"];
                        dr["Price"] = ValueRow["Price"];
                        dr["QRCode"] = ValueRow["QRCode"];
                        POSdt.Rows.Add(dr);
                        gridView.DataSource = POSdt;
                        gridView.DataBind();
                    }
                }
                else
                {
                    ViewState[Enums.SessionName.POSdetail.ToString()] = dt;
                    medQuantity.Add(dt.Rows[0]["qrcode"].ToString(), Convert.ToInt32(dt.Rows[0]["quantity"]));
                    ViewState[Enums.SessionName.MedicineDetail.ToString()] = medQuantity;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var dt = (DataTable)ViewState[Enums.SessionName.POSdetail.ToString()];

        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            ViewState[Enums.SessionName.MedicineDetail.ToString()] = null;
            ViewState[Enums.SessionName.POSdetail.ToString()] = null;
            gridView.DataSource = null;
            gridView.DataBind();
            txt_cust.Text = "";
            txt_total.Text = "";
            txt_qrode.Text = "";
        }
        public PharmacyInventoryModel MapModelForQRCode()
        {
            return new PharmacyInventoryModel()
            {
                PharmacyID = Convert.ToInt32(PharmacyID),
                MedicineID = Convert.ToInt32(txt_qrode.Text)
            };
        }

    }
}