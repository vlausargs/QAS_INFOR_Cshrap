//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IJobSplitValidation
    {
        int JobSplitValidationSp(JobType PJob,
                                 SuffixType PSuffix,
                                 IntType PToJob,
                                 ref InfobarType Infobar);
    }

    public class JobSplitValidation : IJobSplitValidation
    {
        readonly IApplicationDB appDB;

        public JobSplitValidation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int JobSplitValidationSp(JobType PJob,
                                        SuffixType PSuffix,
                                        IntType PToJob,
                                        ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "JobSplitValidationSp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToJob", PToJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
