//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemReleaseWoRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPsitemReleaseWoRouting
    {
        int PsitemReleaseWoRoutingSp(JobType PJob,
                                     ref ListYesNoType ReleaseExistWoRouting);
    }

    public class PsitemReleaseWoRouting : IPsitemReleaseWoRouting
    {
        readonly IApplicationDB appDB;

        public PsitemReleaseWoRouting(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PsitemReleaseWoRoutingSp(JobType PJob,
                                            ref ListYesNoType ReleaseExistWoRouting)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PsitemReleaseWoRoutingSp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReleaseExistWoRouting", ReleaseExistWoRouting, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
