//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitPreassignedLots.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobSplitPreassignedLots
    {
        int JobSplitPreassignedLotsSp(JobType NewJob,
                                      SuffixType NewSuffix,
                                      JobType Job,
                                      SuffixType Suffix,
                                      ItemType Item,
                                      LotType Lot,
                                      QtyUnitType Qty,
                                      ref InfobarType Infobar,
                                      ListYesNoType Copy);
    }

    public class JobSplitPreassignedLots : IJobSplitPreassignedLots
    {
        readonly IApplicationDB appDB;

        public JobSplitPreassignedLots(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobSplitPreassignedLotsSp(JobType NewJob,
                                             SuffixType NewSuffix,
                                             JobType Job,
                                             SuffixType Suffix,
                                             ItemType Item,
                                             LotType Lot,
                                             QtyUnitType Qty,
                                             ref InfobarType Infobar,
                                             ListYesNoType Copy)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobSplitPreassignedLotsSp";

                appDB.AddCommandParameter(cmd, "NewJob", NewJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewSuffix", NewSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Lot", Lot, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Qty", Qty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Copy", Copy, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
