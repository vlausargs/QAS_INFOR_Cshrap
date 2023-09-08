//PROJECT NAME: CSIEmployee
//CLASS NAME: Pr23rFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class Pr23rFactory
    {
        public IPr23r Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _Pr23r = new Pr23r(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPr23rExt = timerfactory.Create<IPr23r>(_Pr23r);

            return iPr23rExt;
        }
    }
}
