//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitPreassignedSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobSplitPreassignedSerials
    {
        int JobSplitPreassignedSerialsSp(JobType NewJob,
                                         SuffixType NewSuffix,
                                         ItemType Item,
                                         SerNumType SerNum,
                                         ref InfobarType Infobar);
    }

    public class JobSplitPreassignedSerials : IJobSplitPreassignedSerials
    {
        readonly IApplicationDB appDB;

        public JobSplitPreassignedSerials(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobSplitPreassignedSerialsSp(JobType NewJob,
                                                SuffixType NewSuffix,
                                                ItemType Item,
                                                SerNumType SerNum,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobSplitPreassignedSerialsSp";

                appDB.AddCommandParameter(cmd, "NewJob", NewJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewSuffix", NewSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SerNum", SerNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
