//PROJECT NAME: CSICustomer
//CLASS NAME: Home_MetricCashImpact.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHome_MetricCashImpact
    {
        DataTable Home_MetricCashImpactSp();
    }

    public class Home_MetricCashImpact : IHome_MetricCashImpact
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public Home_MetricCashImpact(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable Home_MetricCashImpactSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Home_MetricCashImpactSp";

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
