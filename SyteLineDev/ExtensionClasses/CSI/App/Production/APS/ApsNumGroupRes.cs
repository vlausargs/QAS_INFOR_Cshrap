//PROJECT NAME: CSIAPS
//CLASS NAME: ApsNumGroupRes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsNumGroupRes
    {
        int ApsNumGroupResSp(ApsResgroupType PRGID,
                             ref IntType PNumGroupRes,
                             ApsAltNoType AltNo);
    }

    public class ApsNumGroupRes : IApsNumGroupRes
    {
        readonly IApplicationDB appDB;

        public ApsNumGroupRes(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsNumGroupResSp(ApsResgroupType PRGID,
                                    ref IntType PNumGroupRes,
                                    ApsAltNoType AltNo)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsNumGroupResSp";

                appDB.AddCommandParameter(cmd, "PRGID", PRGID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNumGroupRes", PNumGroupRes, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "AltNo", AltNo, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
