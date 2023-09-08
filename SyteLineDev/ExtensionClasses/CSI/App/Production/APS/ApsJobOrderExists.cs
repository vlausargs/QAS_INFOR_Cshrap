//PROJECT NAME: CSIAPS
//CLASS NAME: ApsJobOrderExists.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsJobOrderExists
    {
        int ApsJobOrderExistsSp(JobType Job,
                                SuffixType Suffix,
                                ref ListYesNoType CTPAllowed);
    }

    public class ApsJobOrderExists : IApsJobOrderExists
    {
        readonly IApplicationDB appDB;

        public ApsJobOrderExists(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsJobOrderExistsSp(JobType Job,
                                       SuffixType Suffix,
                                       ref ListYesNoType CTPAllowed)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsJobOrderExistsSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CTPAllowed", CTPAllowed, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
