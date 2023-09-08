//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerTeamSetCerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISSSFSPartnerTeamSetCerts
    {
        int SSSFSPartnerTeamSetCertsSp(FSPartnerType PartnerId,
                                       ref Infobar Infobar);
    }

    public class SSSFSPartnerTeamSetCerts : ISSSFSPartnerTeamSetCerts
    {
        readonly IApplicationDB appDB;

        public SSSFSPartnerTeamSetCerts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSPartnerTeamSetCertsSp(FSPartnerType PartnerId,
                                              ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSPartnerTeamSetCertsSp";

                appDB.AddCommandParameter(cmd, "PartnerId", PartnerId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
