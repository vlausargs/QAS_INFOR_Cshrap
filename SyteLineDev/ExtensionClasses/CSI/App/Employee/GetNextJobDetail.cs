//PROJECT NAME: CSIEmployee
//CLASS NAME: GetNextJobDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetNextJobDetail
    {
        int GetNextJobDetailSp(JobIdType JobId,
                               ref JobDetailType JobDetail,
                               ref InfobarType Infobar);
    }

    public class GetNextJobDetail : IGetNextJobDetail
    {
        readonly IApplicationDB appDB;

        public GetNextJobDetail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetNextJobDetailSp(JobIdType JobId,
                                      ref JobDetailType JobDetail,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetNextJobDetailSp";

                appDB.AddCommandParameter(cmd, "JobId", JobId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobDetail", JobDetail, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
