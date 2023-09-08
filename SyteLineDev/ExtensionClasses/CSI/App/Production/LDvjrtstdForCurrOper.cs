//PROJECT NAME: CSIProduct
//CLASS NAME: LDvjrtstdForCurrOper.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ILDvjrtstdForCurrOper
    {
        int LDvjrtstdForCurrOperSp(JobType Job,
                                   SuffixType Suffix,
                                   JobTypeType JobType,
                                   OperNumType OperNum,
                                   WcType Wc,
                                   ref InputMaskType QtyPerFormat,
                                   ref ListYesNoType EcnTrack,
                                   ref ListYesNoType SchedDriverEnable,
                                   ref ListYesNoType FixedScheduleCheck,
                                   ref ListYesNoType SchedHrsEnable,
                                   ref ListYesNoType UseOffsetCheck,
                                   ref ListYesNoType OffsetHoursEnable,
                                   ref Infobar Infobar);
    }

    public class LDvjrtstdForCurrOper : ILDvjrtstdForCurrOper
    {
        readonly IApplicationDB appDB;

        public LDvjrtstdForCurrOper(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int LDvjrtstdForCurrOperSp(JobType Job,
                                          SuffixType Suffix,
                                          JobTypeType JobType,
                                          OperNumType OperNum,
                                          WcType Wc,
                                          ref InputMaskType QtyPerFormat,
                                          ref ListYesNoType EcnTrack,
                                          ref ListYesNoType SchedDriverEnable,
                                          ref ListYesNoType FixedScheduleCheck,
                                          ref ListYesNoType SchedHrsEnable,
                                          ref ListYesNoType UseOffsetCheck,
                                          ref ListYesNoType OffsetHoursEnable,
                                          ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "LDvjrtstdForCurrOperSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobType", JobType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OperNum", OperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Wc", Wc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtyPerFormat", QtyPerFormat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EcnTrack", EcnTrack, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SchedDriverEnable", SchedDriverEnable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FixedScheduleCheck", FixedScheduleCheck, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SchedHrsEnable", SchedHrsEnable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UseOffsetCheck", UseOffsetCheck, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OffsetHoursEnable", OffsetHoursEnable, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
