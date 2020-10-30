using Generics;
using Generics.Cache;
using Models.Users;
using System;
using System.Collections;
using System.Data;

namespace BLL.Users
{
    public class UsersHandler : ActionHandler<UserModel>
    {
        public DataTable dt;

        public override void DoFillGridAction()
        {
            SQLHandler sql = new SQLHandler();
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetUsers"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "UsersHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Users"
                });
            }
        }
        public override void DoFillBackPanelAction(int ID)
        {
            SQLHandler sql = new SQLHandler(new ArrayList() { ID });
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetUser"));
            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "UsersHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound),
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Users"
                });
            }
        }
        public override void Insert(UserModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.Password,
                model.AccessLevel
            };
            if ((int)Enums.AccessLevel.Admin == model.AccessLevel)
            {
                Params.Add(DBNull.Value);
                Params.Add(DBNull.Value);
            }
            else if ((int)Enums.AccessLevel.CompanyAdmin == model.AccessLevel)
            {
                Params.Add(model.AccessLevel);
                Params.Add(DBNull.Value);
            }
            else if ((int)Enums.AccessLevel.CompanyAdmin == model.AccessLevel)
            {
                Params.Add(DBNull.Value);
                Params.Add(model.AccessLevel);
            }


            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("InsertUser"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Update(UserModel model)
        {
            var Params = new ArrayList()
            {
                model.Name,
                model.Password,
                model.AccessLevel
            };
            if ((int)Enums.AccessLevel.Admin == model.AccessLevel)
            {
                Params.Add(DBNull.Value);
                Params.Add(DBNull.Value);
            }
            else if ((int)Enums.AccessLevel.CompanyAdmin == model.AccessLevel)
            {
                Params.Add(model.AccessLevel);
                Params.Add(DBNull.Value);
            }
            else if ((int)Enums.AccessLevel.CompanyAdmin == model.AccessLevel)
            {
                Params.Add(DBNull.Value);
                Params.Add(model.AccessLevel);
            }

            Params.Add(model.ID);

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("UpdateUser"));
            MessageCollection.copyFrom(sql.Messages);
        }
        public override void Delete(int ID)
        {
            var Params = new ArrayList() { ID };

            SQLHandler sql = new SQLHandler(Params);
            sql.ExecuteNonQuery(SqlCache.GetSql("DeleteUser"));
            MessageCollection.copyFrom(sql.Messages);
        }

        public void FillCompanyDllAction(int accessLevel)
        {
            SQLHandler sql = new SQLHandler();

            if ((int)Enums.AccessLevel.CompanyAdmin == accessLevel)
                dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetUserPharmaCompany"));
            else if ((int)Enums.AccessLevel.Operator == accessLevel)
                dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetUserPharmacy"));

            MessageCollection.copyFrom(sql.Messages);

            if (dt == null || dt.Rows.Count <= 0)
            {
                MessageCollection.addMessage(new Message()
                {
                    Context = "UsersHandler",
                    ErrorCode = ErrorCache.RecordsNotFound,
                    ErrorMessage = ErrorCache.getErrorMessage(ErrorCache.RecordsNotFound) + " in Company/Pharmacy Table",
                    isError = true,
                    LogType = Enums.LogType.Exception,
                    WebPage = "Users"
                });
            }
        }

        public override void DoAction()
        {
            throw new NotImplementedException();
        }
    }
}
