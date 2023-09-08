//PROJECT NAME: CSICustomer
//CLASS NAME: AREFTImportValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IAREFTImportValidate
    {
        int AREFTImportValidateSp(SiteType SourceSite,
                                  ARImportBatchIdType BatchId,
                                  ref InfobarType Infobar);
    }

    public class AREFTImportValidate : IAREFTImportValidate
    {
        readonly IApplicationDB appDB;

        public AREFTImportValidate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AREFTImportValidateSp(SiteType SourceSite,
                                         ARImportBatchIdType BatchId,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AREFTImportValidateSp";

                appDB.AddCommandParameter(cmd, "SourceSite", SourceSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BatchId", BatchId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
