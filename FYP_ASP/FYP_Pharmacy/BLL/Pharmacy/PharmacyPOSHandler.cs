using Generics;
using Generics.Cache;
using Models.Pharmacy;
using System.Collections;
using System.Data;

namespace BLL.Pharmacy
{
    public class PharmacyPOSHandler : ActionHandler<PharmacyInventoryModel>
    {
        DataTable dt = new DataTable();

        public void InsertCustomer(PharmacyInventoryModel Model)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { Model.CustomerName });
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertCustomer"));
            MessageCollection.copyFrom(sql.Messages);

            sql = new SQLHandler(new ArrayList() {  Model.CustomerName, Model.Amount });
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertPurchaseDetails"));
            MessageCollection.copyFrom(sql.Messages);

        }
        public override void Delete(int ID)
        {
            throw new System.NotImplementedException();
        }

        public override void DoAction()
        {
            throw new System.NotImplementedException();
        }

        public override void DoFillBackPanelAction(int ID)
        {
            throw new System.NotImplementedException();
        }

        public override void DoFillGridAction()
        {
            throw new System.NotImplementedException();
        }

        public DataTable GetMedicine(PharmacyInventoryModel model)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { model.PharmacyID, model.MedicineID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPOSMedicine"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmacyPOSHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "PharmacyPOS"
                });
            }
            return dt;
        }

        public override void Insert(PharmacyInventoryModel Model)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(PharmacyInventoryModel Model)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { Model.ID });
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdatePharmacyPOSInventory"));
            MessageCollection.copyFrom(sql.Messages);
        }

    }
}
