//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpDisableExpedite.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpDisableExpedite
    {
        int ApsCtpDisableExpediteSp(ref ListYesNoType PDisableExpedite);
    }

    public class ApsCtpDisableExpedite : IApsCtpDisableExpedite
    {
        readonly IApplicationDB appDB;

        public ApsCtpDisableExpedite(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpDisableExpediteSp(ref ListYesNoType PDisableExpedite)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpDisableExpediteSp";

                appDB.AddCommandParameter(cmd, "PDisableExpedite", PDisableExpedite, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
