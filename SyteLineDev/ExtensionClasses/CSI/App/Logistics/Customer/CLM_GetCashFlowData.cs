//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetCashFlowData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICLM_GetCashFlowData
    {
        DataTable CLM_GetCashFlowDataSp(string SiteRef);
    }

    public class CLM_GetCashFlowData : ICLM_GetCashFlowData
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_GetCashFlowData(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_GetCashFlowDataSp(string SiteRef)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                SiteType _SiteRef = SiteRef;

                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_GetCashFlowDataSp";

                    appDB.AddCommandParameter(cmd, "SiteRef", _SiteRef, ParameterDirection.Input);

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
