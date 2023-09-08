//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBBudRollFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class MultiFSBBudRollFactory
    {
        public IMultiFSBBudRoll Create(IApplicationDB appDB)
        {
            var _MultiFSBBudRoll = new MultiFSBBudRoll(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFsbChartBPsExt = timerfactory.Create<IMultiFSBBudRoll>(_MultiFSBBudRoll);

            return iSLFsbChartBPsExt;
        }
    }
}
