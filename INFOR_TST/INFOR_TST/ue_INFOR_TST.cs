using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

using Mongoose.Core.Common;
using Mongoose.Core.DataAccess;
using Mongoose.IDO.DataAccess;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System.IO;

namespace ue_INFOR_TST
{
    [IDOExtensionClass("ue_INFOR_TST")]
    public partial class ue_INFOR_TST : IDOExtensionClass
    {
        // Add methods and event handlers here

        // Event handlers should be added using attributes.  For example: 

        // [IDOAddEventHandler( IDOEvent.PreItemDelete )]
        // private void OnPreItemDelete( object sender, IDOItemUpdateEventArgs args )
        // {
        // }
        //
        // [IDOAddEventHandler( IDOEvent.PostLoadCollection )]
        // private void OnPostLoadCollection( object sender, IDOEventArgs args )
        // {
        //    var response = args.ResponsePayload as LoadCollectionResponseData;
        // }
        public void ToCSV( DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        public IDataReader example_loadItem(String pItem)
        {
            try
            {
                using (ApplicationDB db = this.CreateApplicationDB())
                {
                    IDbCommand sqlCommand = db.CreateCommand();
                    String res = String.Empty;
                    sqlCommand.CommandText = String.Format("SELECT itm.item, itm.description from item_mst as itm where itm.item = '{0}'", pItem);
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
                    ToCSV(dt, "export.csv");
                    return dt.CreateDataReader();
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