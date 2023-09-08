//PROJECT NAME: CSIFinance
//CLASS NAME: GetSiteInfoFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GetSiteInfoFactory
    {
        public IGetSiteInfo Create(IApplicationDB appDB)
        {
            var _GetSiteInfo = new GetSiteInfo(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartsExt = timerfactory.Create<IGetSiteInfo>(_GetSiteInfo);

            return iSLChartsExt;
        }
    }
}
