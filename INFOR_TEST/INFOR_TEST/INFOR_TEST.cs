using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using Mongoose.IDO.DataAccess;
using Mongoose.Core.Common;



namespace INFOR_TEST
{
    public class INFOR_TEST : IDOExtensionClass
    {
        public override void SetContext(IIDOExtensionClassContext context)
        {
            base.SetContext(context);
            
        }
   
        public IDataReader example_loadItem(String pItem)
        {
            try
            {
                using (ApplicationDB db = this.CreateApplicationDB())
                {
                    IDbCommand sqlCommand = db.CreateCommand();
                    String res = String.Empty;
                    sqlCommand.CommandText = String.Format("SELECT itm.item, itm.description from item_mst as itm where itm.item = {0}", pItem);
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    return sqlCommand.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                DataTable dt = new DataTable();
                return dt.CreateDataReader();
            }
        }
    }
}