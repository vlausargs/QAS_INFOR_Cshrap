//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerTeamSetCertsFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SSSFSPartnerTeamSetCertsFactory
    {
        public ISSSFSPartnerTeamSetCerts Create(IApplicationDB appDB)
        {
            var _SSSFSPartnerTeamSetCerts = new SSSFSPartnerTeamSetCerts(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSPartnerTeamSetCertsExt = timerfactory.Create<ISSSFSPartnerTeamSetCerts>(_SSSFSPartnerTeamSetCerts);

            return iSSSFSPartnerTeamSetCertsExt;
        }
    }
}