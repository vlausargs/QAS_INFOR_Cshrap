//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxPostNeededFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrtrxPostNeededFactory
    {
        public IPrtrxPostNeeded Create(IApplicationDB appDB)
        {
            var _PrtrxPostNeeded = new PrtrxPostNeeded(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrtrxPostNeededExt = timerfactory.Create<IPrtrxPostNeeded>(_PrtrxPostNeeded);

            return iPrtrxPostNeededExt;
        }
    }
}
