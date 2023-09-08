//PROJECT NAME: CSIEmployee
//CLASS NAME: PrParmsShiftFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PrParmsShiftFactory
    {
        public IPrParmsShift Create(IApplicationDB appDB)
        {
            var _PrParmsShift = new PrParmsShift(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPrParmsShiftExt = timerfactory.Create<IPrParmsShift>(_PrParmsShift);

            return iPrParmsShiftExt;
        }
    }
}
