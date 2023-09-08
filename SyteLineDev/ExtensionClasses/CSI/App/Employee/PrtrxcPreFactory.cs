//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxcPreFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrtrxcPreFactory
    {
        public IPrtrxcPre Create(IApplicationDB appDB)
        {
            var _PrtrxcPre = new PrtrxcPre(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrtrxcPreExt = timerfactory.Create<IPrtrxcPre>(_PrtrxcPre);

            return iPrtrxcPreExt;
        }
    }
}
