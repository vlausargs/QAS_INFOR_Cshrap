//PROJECT NAME: CSIProduct
//CLASS NAME: JobGenMix1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobGenMix1
    {
        int JobGenMix1Sp(JobType PJob,
                         SuffixType PSuffix,
                         RowPointerType SessionID,
                         ref Infobar Infobar);
    }

    public class JobGenMix1 : IJobGenMix1
    {
        readonly IApplicationDB appDB;

        public JobGenMix1(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobGenMix1Sp(JobType PJob,
                                SuffixType PSuffix,
                                RowPointerType SessionID,
                                ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobGenMix1Sp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
