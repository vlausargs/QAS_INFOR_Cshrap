//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxgPreCheckFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrtrxgPreCheckFactory
    {
        public IPrtrxgPreCheck Create(IApplicationDB appDB)
        {
            var _PrtrxgPreCheck = new PrtrxgPreCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrtrxgPreCheckExt = timerfactory.Create<IPrtrxgPreCheck>(_PrtrxgPreCheck);

            return iPrtrxgPreCheckExt;
        }
    }
}
