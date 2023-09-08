//PROJECT NAME: CSIAPS
//CLASS NAME: ApsGetPlannerValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsGetPlannerValues
    {
        int ApsGetPlannerValuesSp(ApsAltNoType ALTNO,
                                  ref ApsIntType OrdLate,
                                  ref ApsIntType MfgItemShort,
                                  ref ApsIntType PurItemShort,
                                  ref ApsIntType RGBottle,
                                  ref ApsIntType ItemBottle);
    }

    public class ApsGetPlannerValues : IApsGetPlannerValues
    {
        readonly IApplicationDB appDB;

        public ApsGetPlannerValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsGetPlannerValuesSp(ApsAltNoType ALTNO,
                                         ref ApsIntType OrdLate,
                                         ref ApsIntType MfgItemShort,
                                         ref ApsIntType PurItemShort,
                                         ref ApsIntType RGBottle,
                                         ref ApsIntType ItemBottle)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsGetPlannerValuesSp";

                appDB.AddCommandParameter(cmd, "ALTNO", ALTNO, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrdLate", OrdLate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "MfgItemShort", MfgItemShort, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PurItemShort", PurItemShort, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RGBottle", RGBottle, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemBottle", ItemBottle, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
