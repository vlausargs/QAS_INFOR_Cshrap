//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranNextOperValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobtranNextOperValid
    {
        int JobtranNextOperValidSp(JobType InJob,
                                   SuffixType InSuffix,
                                   OperNumType InNextOper,
                                   ref WcType Wc,
                                   ref DescriptionType WcDesc,
                                   ref InfobarType Infobar);
    }

    public class JobtranNextOperValid : IJobtranNextOperValid
    {
        readonly IApplicationDB appDB;

        public JobtranNextOperValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobtranNextOperValidSp(JobType InJob,
                                          SuffixType InSuffix,
                                          OperNumType InNextOper,
                                          ref WcType Wc,
                                          ref DescriptionType WcDesc,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobtranNextOperValidSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InNextOper", InNextOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Wc", Wc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "WcDesc", WcDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
