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


namespace KDU_DPP
{
    [IDOExtensionClass("KDU_DPP")]
    public partial class KDU_DPP : IDOExtensionClass
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

        public IDataReader dataview_load(String pItem)
        {
            try
            {
                using (ApplicationDB db = this.CreateApplicationDB())
                {
                    IDbCommand sqlCommand = db.CreateCommand();
                    String res = String.Empty;
                    sqlCommand.CommandText = String.Format("SELECT " +
                        "art.amount, " +
                        "art.apply_to_inv_num, " +
                        "art.description," +
                        "art.ref, " +
                        "invhdr.bill_type, " +
                        "invhdr.co_num, " +
                        "invhdr.cust_num, " +
                        "invhdr.cust_po, " +
                        "invhdr.cust_seq, " +
                        "art.due_date, " +
                        "invhdr.inv_date, " +
                        "invhdr.inv_num, " +
                        "invhdr.inv_seq, " +
                        "invhdr.UfFlagInvalid as invalid, " +
                        "invhdr.price, " +
                        "art.sales_tax, " +
                        "invhdr.ship_date, " +
                        "invhdr.shipment_id, " +
                        "invhdr.slsman, " +
                        "invhdr.terms_code, " +
                        "art.type, " +
                        "invhdr.UfFPDate, " +
                        "invhdr.UfFPNo, " +
                        "w.city as DerCity, " +
                        "caddr.name as  DerName, " +
                        "ISNULL((select sum( a.amount + a.sales_tax) from artran as a where a.type = 'C' and a.apply_to_inv_num = invhdr.inv_num),0) as DerCN, " +
                        "ISNULL((select sum( a.amount ) from artran as a where a.type = 'P' and a.apply_to_inv_num = invhdr.inv_num),0) as DerPayment" +
                        "from inv_hdr as invhdr " +
                        "left outer join artran as art on art.inv_num = invhdr.inv_num " +
                        "join customer cust on cust.cust_num = invhdr.cust_num and cust.cust_seq = invhdr.cust_seq " +
                        "join whse as w on w.whse = cust.whse " +
                        "join custaddr as caddr on caddr.cust_num = invhdr.cust_num and caddr.cust_seq = invhdr.cust_seq" +
                        "where itm.item = '{0}'", pItem);
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    DataTable dt = new DataTable();
                    dt.Load(sqlCommand.ExecuteReader());
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
