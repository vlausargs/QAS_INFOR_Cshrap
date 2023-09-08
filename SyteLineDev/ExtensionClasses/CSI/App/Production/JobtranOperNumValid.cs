//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranOperNumValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranOperNumValid
    {
        int JobtranOperNumValidSp(JobtranTypeType TransType,
                                  JobType InJob,
                                  SuffixType InSuffix,
                                  OperNumType InOperNum,
                                  ref OperNumType OldOperNum,
                                  ref ListYesNoType CntrlPoint,
                                  ref WcType Wc,
                                  ref DescriptionType WcDesc,
                                  ref CostCodeType CostCode,
                                  ref OperNumType NextOper,
                                  ref WcType NextWc,
                                  ref DescriptionType NextWcDesc,
                                  ref LocType Loc,
                                  ref DescriptionType LocDesc,
                                  ref ListYesNoType OperComplete,
                                  ref InfobarType PromptMsg,
                                  ref InfobarType PromptButtons,
                                  ref InfobarType Infobar,
                                  ref QtyUnitType JobQtyPerSheet);
    }

    public class JobtranOperNumValid : IJobtranOperNumValid
    {
        readonly IApplicationDB appDB;

        public JobtranOperNumValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranOperNumValidSp(JobtranTypeType TransType,
                                         JobType InJob,
                                         SuffixType InSuffix,
                                         OperNumType InOperNum,
                                         ref OperNumType OldOperNum,
                                         ref ListYesNoType CntrlPoint,
                                         ref WcType Wc,
                                         ref DescriptionType WcDesc,
                                         ref CostCodeType CostCode,
                                         ref OperNumType NextOper,
                                         ref WcType NextWc,
                                         ref DescriptionType NextWcDesc,
                                         ref LocType Loc,
                                         ref DescriptionType LocDesc,
                                         ref ListYesNoType OperComplete,
                                         ref InfobarType PromptMsg,
                                         ref InfobarType PromptButtons,
                                         ref InfobarType Infobar,
                                         ref QtyUnitType JobQtyPerSheet)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranOperNumValidSp";

                appDB.AddCommandParameter(cmd, "TransType", TransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldOperNum", OldOperNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CntrlPoint", CntrlPoint, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Wc", Wc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WcDesc", WcDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CostCode", CostCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NextOper", NextOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NextWc", NextWc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NextWcDesc", NextWcDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Loc", Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LocDesc", LocDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OperComplete", OperComplete, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobQtyPerSheet", JobQtyPerSheet, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
