//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranCloseJobValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranCloseJobValid
    {
        int JobtranCloseJobValidSp(JobType InJob,
                                   SuffixType InSuffix,
                                   ListYesNoType InCloseJob,
                                   ref InfobarType PromptMsg,
                                   ref InfobarType PromptButtons);
    }

    public class JobtranCloseJobValid : IJobtranCloseJobValid
    {
        readonly IApplicationDB appDB;

        public JobtranCloseJobValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranCloseJobValidSp(JobType InJob,
                                          SuffixType InSuffix,
                                          ListYesNoType InCloseJob,
                                          ref InfobarType PromptMsg,
                                          ref InfobarType PromptButtons)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranCloseJobValidSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InCloseJob", InCloseJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
