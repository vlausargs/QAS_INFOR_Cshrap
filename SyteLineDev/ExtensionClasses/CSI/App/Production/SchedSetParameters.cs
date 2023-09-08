//PROJECT NAME: CSIProduct
//CLASS NAME: SchedSetParameters.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ISchedSetParameters
    {
        int SchedSetParametersSp(ApsAltNoType AltNo,
                                 ApsShiftType MFBSHIFTID);
    }

    public class SchedSetParameters : ISchedSetParameters
    {
        readonly IApplicationDB appDB;

        public SchedSetParameters(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SchedSetParametersSp(ApsAltNoType AltNo,
                                        ApsShiftType MFBSHIFTID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SchedSetParametersSp";

                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MFBSHIFTID", MFBSHIFTID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
