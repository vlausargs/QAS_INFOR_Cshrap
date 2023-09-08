//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsRemoteWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpIsRemoteWhse
    {
        int ApsCtpIsRemoteWhseSp(WhseType PWhse,
                                 ref FlagNyType PIsRemote);
    }

    public class ApsCtpIsRemoteWhse : IApsCtpIsRemoteWhse
    {
        readonly IApplicationDB appDB;

        public ApsCtpIsRemoteWhse(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpIsRemoteWhseSp(WhseType PWhse,
                                        ref FlagNyType PIsRemote)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpIsRemoteWhseSp";

                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIsRemote", PIsRemote, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
