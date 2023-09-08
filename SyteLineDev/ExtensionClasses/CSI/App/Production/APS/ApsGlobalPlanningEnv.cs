//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGlobalPlanningEnv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGlobalPlanningEnv
    {
        int ApsGlobalPlanningEnvSp(ApsAltNoType AltNo,
                                   ref Flag GlobalPlanning);
    }

    public class ApsGlobalPlanningEnv : IApsGlobalPlanningEnv
    {
        readonly IApplicationDB appDB;

        public ApsGlobalPlanningEnv(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGlobalPlanningEnvSp(ApsAltNoType AltNo,
                                          ref Flag GlobalPlanning)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGlobalPlanningEnvSp";

                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GlobalPlanning", GlobalPlanning, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
