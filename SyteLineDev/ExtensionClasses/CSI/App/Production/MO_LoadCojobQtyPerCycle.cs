//PROJECT NAME: CSIProduct
//CLASS NAME: MO_LoadCojobQtyPerCycle.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IMO_LoadCojobQtyPerCycle
    {
        int MO_LoadCojobQtyPerCycleSp(JobType Job,
                                      SuffixType Suffix,
                                      OperNumType OperNum,
                                      ref ListYesNoType MOCoJob,
                                      ref QtyUnitType JobQtyPerCycle,
                                      ref ListYesNoType Shared);
    }

    public class MO_LoadCojobQtyPerCycle : IMO_LoadCojobQtyPerCycle
    {
        readonly IApplicationDB appDB;

        public MO_LoadCojobQtyPerCycle(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MO_LoadCojobQtyPerCycleSp(JobType Job,
                                             SuffixType Suffix,
                                             OperNumType OperNum,
                                             ref ListYesNoType MOCoJob,
                                             ref QtyUnitType JobQtyPerCycle,
                                             ref ListYesNoType Shared)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MO_LoadCojobQtyPerCycleSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MOCoJob", MOCoJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobQtyPerCycle", JobQtyPerCycle, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Shared", Shared, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
