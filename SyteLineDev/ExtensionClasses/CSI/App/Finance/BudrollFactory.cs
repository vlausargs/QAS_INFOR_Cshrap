//PROJECT NAME: CSIFinance
//CLASS NAME: BudrollFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class BudrollFactory
    {
        public IBudroll Create(IApplicationDB appDB)
        {
            var _Budroll = new Budroll(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartBpsExt = timerfactory.Create<IBudroll>(_Budroll);

            return iSLChartBpsExt;
        }
    }
}
