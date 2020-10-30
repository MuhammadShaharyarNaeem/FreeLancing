using Generics;
using Generics.Cache;
using Models.Pharmacy;
using System;
using System.Collections;
using System.Data;

namespace BLL.Pharmacy
{
    public class PharmacyHandler : ActionHandler<PharmacyModel>
    {
        public DataTable dt = new DataTable();

        public override void DoFillGridAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmacys"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmacyHandler",
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
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmacy"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmacyHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Pharmacy"
                });
            }
        }
        public override void Insert(PharmacyModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.Email,
                model.ContactNumber,
                model.Description,
                model.Address,
                model.RegistrationNumber
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertPharmacy"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Update(PharmacyModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.Email,
                model.ContactNumber,
                model.Description,
                model.Address,
                model.ID
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdatePharmacy"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Delete(int ID)
        {
            var Params = new ArrayList() { ID };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DeletePharmacy"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
