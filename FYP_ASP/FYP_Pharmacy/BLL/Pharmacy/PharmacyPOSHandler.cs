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
            SQLHandler sql = new SQLHandler(new ArrayList() { Model.MedicineID, Model.Quantity, Model.ID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("UpdatePharmacyPOSInventory"));
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
        }

    }
}
