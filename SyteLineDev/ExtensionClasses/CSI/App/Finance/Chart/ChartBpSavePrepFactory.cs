//PROJECT NAME: CSIFinance
//CLASS NAME: ChartBpSavePrepFactory.cs

using CSI.MG;

namespace CSI.Finance.Chart
{
    public class ChartBpSavePrepFactory
    {
        public IChartBpSavePrep Create(IApplicationDB appDB)
        {
            var _ChartBpSavePrep = new ChartBpSavePrep(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLChartBpsExt = timerfactory.Create<IChartBpSavePrep>(_ChartBpSavePrep);

            return iSLChartBpsExt;
        }
    }
}
