using Generics;
using Generics.Cache;
using Models.Medicine;
using System;
using System.Collections;
using System.Data;
using System.Web.ModelBinding;

namespace BLL.Medicine
{
    public class MedicineHandler : ActionHandler<MedicineModel>
    {
        public DataTable dt = new DataTable();
        public override void DoFillGridAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetMedicines"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "MedicineHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Medicine"
                });
            }
        }
        public void GetMedicineAgainstQRCode(string qrcode,DataTable viewData,int pharmacyid)
        {            
            SQLHandler sql = new SQLHandler(new ArrayList() { qrcode });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetMedicinesForQRCode"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "MedicineHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Medicine"
                });
            }
            Decrementquantity(dt.Rows[0].Field<int>("pharmacyid"), dt.Rows[0].Field<int>("medicineid"));
            viewData.Rows.Add(dt.Rows[0]);
            dt = viewData;
           
        }
        public override void DoFillBackPanelAction(int ID)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { ID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetMedicine"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "MedicineHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Medicine"
                });
            }
        }
        public override void Insert(MedicineModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.QRCode,
                model.ExpiryDate,
                model.MfgDate,
                model.BatchNo,
                model.Price,
                model.PharmaCompanyID
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertMedicine"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Update(MedicineModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.QRCode,
                model.ExpiryDate,
                model.MfgDate,
                model.BatchNo,
                model.Price,
                model.ID
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdateMedicine"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Delete(int ID)
        {
            var Params = new ArrayList() { ID };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DeleteMedicine"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public void Decrementquantity(int pharmID,int medid)
        {
            var Params = new ArrayList() { pharmID, medid};

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DecrementPharmacyInventory"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
