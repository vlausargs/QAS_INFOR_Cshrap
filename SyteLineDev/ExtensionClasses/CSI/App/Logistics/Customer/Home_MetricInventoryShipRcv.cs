//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricInventoryShipRcv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricInventoryShipRcv
    {
        DataTable Home_MetricInventoryShipRcvSp();
    }

    public class Home_MetricInventoryShipRcv : IHome_MetricInventoryShipRcv
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Home_MetricInventoryShipRcv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Home_MetricInventoryShipRcvSp()
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Home_MetricInventoryShipRcvSp";

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
