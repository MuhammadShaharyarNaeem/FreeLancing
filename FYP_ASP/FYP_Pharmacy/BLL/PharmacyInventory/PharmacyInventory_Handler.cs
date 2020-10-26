using Generics;
using Generics.Cache;
using Models.Generic;
using System;
using System.Collections;
using System.Data;

namespace BLL.PharmacyInventory
{
    public class PharmacyInventory_Handler : ActionHandler
    {
        public string qr_code;
        SQLHandler sql;
        DataTable dt;

        public override void DoAction()
        {
            ArrayList Params = new ArrayList()
            {
               qr_code
            };

            sql = new SQLHandler(Params);
            dt = sql.ExecuteSqlReterieve(SqlCache.GetSql("GetMedicineData"));
        }

        public DataTable GetData()
        {
            Medicine med = new Medicine();
            MessageCollection.copyFrom(sql.Messages);
            if (!MessageCollection.isErrorOccured)
            {
                if (dt != null && dt.Rows.Count > 0)
                {                    
                    
                    med.Batch_no = dt.Rows[0].Field<string>("batch_no");
                    med.Expiry_Date = dt.Rows[0].Field<DateTime>("expiry_date");
                    med.MFG_Date= dt.Rows[0].Field<DateTime>("mfg_date");
                    med.Name= dt.Rows[0].Field<string>("name");
                    med.price= dt.Rows[0].Field<double>("price");
                    med.Registrant= dt.Rows[0].Field<string>("registrant");
                    med.Registration_no= dt.Rows[0].Field<string>("registration_no");
                }
            }
            else
                MessageCollection.PublishLog();
            return dt;
        }
    }
}
