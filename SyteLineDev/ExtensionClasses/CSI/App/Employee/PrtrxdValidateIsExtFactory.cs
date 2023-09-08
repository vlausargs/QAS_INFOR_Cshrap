//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxdValidateIsExtFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrtrxdValidateIsExtFactory
    {
        public IPrtrxdValidateIsExt Create(IApplicationDB appDB)
        {
            var _PrtrxdValidateIsExt = new PrtrxdValidateIsExt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrtrxdValidateIsExtExt = timerfactory.Create<IPrtrxdValidateIsExt>(_PrtrxdValidateIsExt);

            return iPrtrxdValidateIsExtExt;
        }
    }
}
