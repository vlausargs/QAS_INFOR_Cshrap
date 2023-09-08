//PROJECT NAME: CSIFinance
//CLASS NAME: MultiSiteChartCopyFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiSiteChartCopyFactory
    {
        public IMultiSiteChartCopy Create(IApplicationDB appDB)
        {
            var _MultiSiteChartCopy = new MultiSiteChartCopy(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartsExt = timerfactory.Create<IMultiSiteChartCopy>(_MultiSiteChartCopy);

            return iSLChartsExt;
        }
    }
}
