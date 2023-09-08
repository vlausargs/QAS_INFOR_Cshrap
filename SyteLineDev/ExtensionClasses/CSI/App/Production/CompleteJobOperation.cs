//PROJECT NAME: CSIProduct
//CLASS NAME: CompleteJobOperation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICompleteJobOperation
    {
        int CompleteJobOperationSP(JobType FromJob,
                                   JobType ToJob,
                                   SuffixType FromSuffix,
                                   SuffixType ToSuffix,
                                   OperNumType FromOperation,
                                   OperNumType ToOperation,
                                   ref InfobarType Infobar);
    }

    public class CompleteJobOperation : ICompleteJobOperation
    {
        readonly IApplicationDB appDB;

        public CompleteJobOperation(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CompleteJobOperationSP(JobType FromJob,
                                          JobType ToJob,
                                          SuffixType FromSuffix,
                                          SuffixType ToSuffix,
                                          OperNumType FromOperation,
                                          OperNumType ToOperation,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CompleteJobOperationSP";

                appDB.AddCommandParameter(cmd, "FromJob", FromJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToJob", ToJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSuffix", FromSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSuffix", ToSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromOperation", FromOperation, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToOperation", ToOperation, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
