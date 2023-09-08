//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerTeamSetSkillsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SSSFSPartnerTeamSetSkillsFactory
    {
        public ISSSFSPartnerTeamSetSkills Create(IApplicationDB appDB)
        {
            var _SSSFSPartnerTeamSetSkills = new SSSFSPartnerTeamSetSkills(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSPartnerTeamSetSkillsExt = timerfactory.Create<ISSSFSPartnerTeamSetSkills>(_SSSFSPartnerTeamSetSkills);

            return iSSSFSPartnerTeamSetSkillsExt;
        }
    }
}
