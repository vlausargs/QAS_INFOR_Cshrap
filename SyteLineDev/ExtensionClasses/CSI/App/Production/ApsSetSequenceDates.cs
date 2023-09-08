//PROJECT NAME: CSIProduct
//CLASS NAME: ApsSetSequenceDates.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IApsSetSequenceDates
    {
        int ApsSetSequenceDatesSp(ApsResourceType RESID,
                                  StringType EndDateInterval);
    }

    public class ApsSetSequenceDates : IApsSetSequenceDates
    {
        readonly IApplicationDB appDB;

        public ApsSetSequenceDates(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsSetSequenceDatesSp(ApsResourceType RESID,
                                         StringType EndDateInterval)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsSetSequenceDatesSp";

                appDB.AddCommandParameter(cmd, "RESID", RESID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDateInterval", EndDateInterval, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
