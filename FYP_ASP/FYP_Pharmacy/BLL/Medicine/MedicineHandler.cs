using Generics;
using Generics.Cache;
using Models.Medicine;
using System;
using System.Collections;
using System.Data;

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

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
