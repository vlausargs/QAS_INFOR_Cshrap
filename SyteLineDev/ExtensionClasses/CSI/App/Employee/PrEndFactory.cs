//PROJECT NAME: CSIEmployee
//CLASS NAME: PrEndFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrEndFactory
    {
        public IPrEnd Create(IApplicationDB appDB)
        {
            var _PrEnd = new PrEnd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrEndExt = timerfactory.Create<IPrEnd>(_PrEnd);

            return iPrEndExt;
        }
    }
}
