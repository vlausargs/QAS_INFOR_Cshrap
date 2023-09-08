//PROJECT NAME: CSIFinance
//CLASS NAME: ValidChartAllocationFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class ValidChartAllocationFactory
    {
        public IValidChartAllocation Create(IApplicationDB appDB)
        {
            var _ValidChartAllocation = new ValidChartAllocation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbChartChartsExt = timerfactory.Create<IValidChartAllocation>(_ValidChartAllocation);

            return iSLFsbChartChartsExt;
        }
    }
}
