//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemJobCopy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPsitemJobCopy
    {
        int PsitemJobCopySp(JobType PJob,
                            ListYesNoType PCopyBOMToPSReleases,
                            ListYesNoType PCopyItemBOMToPSBOM,
                            ref InfobarType Infobar);
    }

    public class PsitemJobCopy : IPsitemJobCopy
    {
        readonly IApplicationDB appDB;

        public PsitemJobCopy(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PsitemJobCopySp(JobType PJob,
                                   ListYesNoType PCopyBOMToPSReleases,
                                   ListYesNoType PCopyItemBOMToPSBOM,
                                   ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PsitemJobCopySp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCopyBOMToPSReleases", PCopyBOMToPSReleases, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCopyItemBOMToPSBOM", PCopyItemBOMToPSBOM, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
