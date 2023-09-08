//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_ApsGetAltPlanGraph.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface ICLM_ApsGetAltPlanGraph
    {
        DataTable CLM_ApsGetAltPlanGraphSp(ApsAltNoType AltNo);
    }

    public class CLM_ApsGetAltPlanGraph : ICLM_ApsGetAltPlanGraph
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public CLM_ApsGetAltPlanGraph(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable CLM_ApsGetAltPlanGraphSp(ApsAltNoType AltNo)
        {
            bunchedLoadCollection.StartBunching();

            try
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    DataTable dtReturn = new DataTable();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "CLM_ApsGetAltPlanGraphSp";

                    appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);

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
