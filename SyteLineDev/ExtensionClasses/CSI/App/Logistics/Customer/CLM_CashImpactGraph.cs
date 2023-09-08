//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CashImpactGraph.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_CashImpactGraph
    {
        DataTable CLM_CashImpactGraphSp();
    }

    public class CLM_CashImpactGraph : ICLM_CashImpactGraph
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_CashImpactGraph(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_CashImpactGraphSp()
        {
            bunchedLoadCollection.StartBunching();

            try
            {

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_CashImpactGraphSp";

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
