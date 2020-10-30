using Generics;
using Generics.Cache;
using Models.PharmaCompany;
using System;
using System.Collections;
using System.Data;

namespace BLL.PharmaCompany
{
    public class PharmaCompanyHandler : ActionHandler<PharmaCompanyModel>
    {
        public DataTable dt = new DataTable();

        public override void DoFillGridAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmaCompanys"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmaCompanyHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "PharmaCompany"
                });
            }
        }
        public override void DoFillBackPanelAction(int ID)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { ID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetPharmaCompany"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "PharmaCompanyHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "PharmaCompany"
                });
            }
        }
        public override void Insert(PharmaCompanyModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.Email,
                model.ContactNumber,
                model.Description,
                model.Address
            };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertPharmaCompany"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Update(PharmaCompanyModel model)
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
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdatePharmaCompany"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Delete(int ID)
        {
            var Params = new ArrayList() { ID };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DeletePharmaCompany"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
