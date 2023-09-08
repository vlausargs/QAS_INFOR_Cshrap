//PROJECT NAME: FSPlusPartnerExt
//CLASS NAME: FSPartnerTeams.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Partner;
using CSI.MG;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusPartner
{
    [IDOExtensionClass("FSPartnerTeams")]
    public class FSPartnerTeams : ExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSPartnerTeamSetSkillsSp(string PartnerId,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSPartnerTeamSetSkillsExt = new SSSFSPartnerTeamSetSkillsFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSFSPartnerTeamSetSkillsExt.SSSFSPartnerTeamSetSkillsSp(PartnerId,
                                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSPartnerTeamSetCertsSp(string PartnerId,
                                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSPartnerTeamSetCertsExt = new SSSFSPartnerTeamSetCertsFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSFSPartnerTeamSetCertsExt.SSSFSPartnerTeamSetCertsSp(PartnerId,
                                                                                       ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }
    }
}
