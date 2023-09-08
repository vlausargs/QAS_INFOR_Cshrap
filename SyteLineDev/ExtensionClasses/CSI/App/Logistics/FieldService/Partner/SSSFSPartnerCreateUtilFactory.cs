//PROJECT NAME: CSIFSPlusPartner
//CLASS NAME: SSSFSPartnerCreateUtilFactory.cs

using CSI.MG;

namespace CSI.Logistics.FieldService.Partner
{
    public class SSSFSPartnerCreateUtilFactory
    {
        public ISSSFSPartnerCreateUtil Create(IApplicationDB appDB)
        {
            var _SSSFSPartnerCreateUtil = new SSSFSPartnerCreateUtil(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSFSPartnerCreateUtilExt = timerfactory.Create<ISSSFSPartnerCreateUtil>(_SSSFSPartnerCreateUtil);

            return iSSSFSPartnerCreateUtilExt;
        }
    }
}
