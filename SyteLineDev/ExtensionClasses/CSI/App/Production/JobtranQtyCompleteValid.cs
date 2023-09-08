//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranQtyCompleteValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranQtyCompleteValid
    {
        int JobtranQtyCompleteValidSp(JobType InJob,
                                      SuffixType InSuffix,
                                      OperNumType InOperNum,
                                      QtyUnitType InQtyComplete,
                                      ref InfobarType PromptMsg,
                                      ref InfobarType PromptButtons);
    }

    public class JobtranQtyCompleteValid : IJobtranQtyCompleteValid
    {
        readonly IApplicationDB appDB;

        public JobtranQtyCompleteValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranQtyCompleteValidSp(JobType InJob,
                                             SuffixType InSuffix,
                                             OperNumType InOperNum,
                                             QtyUnitType InQtyComplete,
                                             ref InfobarType PromptMsg,
                                             ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranQtyCompleteValidSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InOperNum", InOperNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InQtyComplete", InQtyComplete, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
