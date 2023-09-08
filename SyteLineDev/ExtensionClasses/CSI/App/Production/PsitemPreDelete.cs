//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemPreDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPsitemPreDelete
    {
        int PsitemPreDeleteSp(JobType PPsJob,
                              ref InfobarType Infobar);
    }

    public class PsitemPreDelete : IPsitemPreDelete
    {
        readonly IApplicationDB appDB;

        public PsitemPreDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PsitemPreDeleteSp(JobType PPsJob,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PsitemPreDeleteSp";

                appDB.AddCommandParameter(cmd, "PPsJob", PPsJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
