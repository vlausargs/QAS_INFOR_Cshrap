//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductSyncRatio2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICoProductSyncRatio2
    {
        int CoProductSyncRatio2Sp(JobType PJob,
                                  SuffixType PSuffix,
                                  ref InfobarType Infobar);
    }

    public class CoProductSyncRatio2 : ICoProductSyncRatio2
    {
        readonly IApplicationDB appDB;

        public CoProductSyncRatio2(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoProductSyncRatio2Sp(JobType PJob,
                                         SuffixType PSuffix,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoProductSyncRatio2Sp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
