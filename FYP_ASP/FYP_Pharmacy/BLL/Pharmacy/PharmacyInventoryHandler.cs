using Generics;
using Generics.Cache;
using Models.Pharmacy;
using System;
using System.Collections;
using System.Data;

namespace BLL.Pharmacy
{
    public class PharmacyInventoryHandler : ActionHandler<PharmacyInventoryModel>
    {
        public DataTable dt = new DataTable();

        public override void DoFillGridAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmacyInventory"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmacyInventoryHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Pharmacy"
                });
            }
        }
        public override void DoFillBackPanelAction(int ID)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { ID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmacyInventoryByID"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmacyInventoryHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Pharmacy"
                });
            }
        }
        public override void Insert(PharmacyInventoryModel model)
        {
            var Params = new ArrayList()
            {
                model.MedicineID,
                model.PharmacyID,
                model.Quantity,
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertPharmacyInventory"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Update(PharmacyInventoryModel model)
        {
            var Params = new ArrayList()
            {
                model.MedicineID,
                model.PharmacyID,
                model.Quantity,
                model.ID
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdatePharmacyInventory"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Delete(int ID)
        {
            var Params = new ArrayList() { ID };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DeletePharmacyInventory"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
