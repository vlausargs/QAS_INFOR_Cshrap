//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsScheduled.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpIsScheduled
    {
        int ApsCtpIsScheduledSp(JobType PJob,
                                SuffixType PSuffix,
                                ref IntType PFlag);
    }

    public class ApsCtpIsScheduled : IApsCtpIsScheduled
    {
        readonly IApplicationDB appDB;

        public ApsCtpIsScheduled(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpIsScheduledSp(JobType PJob,
                                       SuffixType PSuffix,
                                       ref IntType PFlag)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpIsScheduledSp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFlag", PFlag, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
