//PROJECT NAME: CSIProduct
//CLASS NAME: DeletePendingJobLaborTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IDeletePendingJobLaborTrans
    {
        int DeletePendingJobLaborTransSp(StringType TransClass,
                                         HugeTransNumType FromTransNum,
                                         HugeTransNumType ToTransNum,
                                         JobType FromJob,
                                         SuffixType FromJobSuffix,
                                         JobType ToJob,
                                         SuffixType ToJobSuffix,
                                         ref InfobarType Infobar);
    }

    public class DeletePendingJobLaborTrans : IDeletePendingJobLaborTrans
    {
        readonly IApplicationDB appDB;

        public DeletePendingJobLaborTrans(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DeletePendingJobLaborTransSp(StringType TransClass,
                                                HugeTransNumType FromTransNum,
                                                HugeTransNumType ToTransNum,
                                                JobType FromJob,
                                                SuffixType FromJobSuffix,
                                                JobType ToJob,
                                                SuffixType ToJobSuffix,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletePendingJobLaborTransSp";

                appDB.AddCommandParameter(cmd, "TransClass", TransClass, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromTransNum", FromTransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToTransNum", ToTransNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromJob", FromJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromJobSuffix", FromJobSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToJob", ToJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToJobSuffix", ToJobSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
