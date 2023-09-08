//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerTeamSetSkills.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public interface ISSSFSPartnerTeamSetSkills
    {
        int SSSFSPartnerTeamSetSkillsSp(FSPartnerType PartnerId,
                                        ref Infobar Infobar);
    }

    public class SSSFSPartnerTeamSetSkills : ISSSFSPartnerTeamSetSkills
    {
        readonly IApplicationDB appDB;

        public SSSFSPartnerTeamSetSkills(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSPartnerTeamSetSkillsSp(FSPartnerType PartnerId,
                                               ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSPartnerTeamSetSkillsSp";

                appDB.AddCommandParameter(cmd, "PartnerId", PartnerId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

