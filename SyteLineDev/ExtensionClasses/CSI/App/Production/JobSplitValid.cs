//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobSplitValid
    {
        int JobSplitValidSp(JobType Job,
                            SuffixType Suffix,
                            JobType NewJob,
                            SuffixType NewSuffix,
                            ref JobType OutNewJob,
                            ref SuffixType OutNewSuffix,
                            ref QtyUnitType QtyReleased,
                            ref QtyUnitType QtyCompleted,
                            ref QtyUnitType QtyToSplit,
                            ref InfobarType Infobar,
                            ref ListYesNoType PreassignLots,
                            ref ListYesNoType PreassignSerials,
                            ref ItemType Item);
    }

    public class JobSplitValid : IJobSplitValid
    {
        readonly IApplicationDB appDB;

        public JobSplitValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobSplitValidSp(JobType Job,
                                   SuffixType Suffix,
                                   JobType NewJob,
                                   SuffixType NewSuffix,
                                   ref JobType OutNewJob,
                                   ref SuffixType OutNewSuffix,
                                   ref QtyUnitType QtyReleased,
                                   ref QtyUnitType QtyCompleted,
                                   ref QtyUnitType QtyToSplit,
                                   ref InfobarType Infobar,
                                   ref ListYesNoType PreassignLots,
                                   ref ListYesNoType PreassignSerials,
                                   ref ItemType Item)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobSplitValidSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewJob", NewJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewSuffix", NewSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OutNewJob", OutNewJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OutNewSuffix", OutNewSuffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyReleased", QtyReleased, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyCompleted", QtyCompleted, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyToSplit", QtyToSplit, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PreassignLots", PreassignLots, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PreassignSerials", PreassignSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
