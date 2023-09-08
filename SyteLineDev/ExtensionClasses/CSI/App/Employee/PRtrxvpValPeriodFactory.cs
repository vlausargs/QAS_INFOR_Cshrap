//PROJECT NAME: CSIEmployee
//CLASS NAME: PRtrxvpValPeriodFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class PRtrxvpValPeriodFactory
    {
        public IPRtrxvpValPeriod Create(IApplicationDB appDB)
        {
            var _PRtrxvpValPeriod = new PRtrxvpValPeriod(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPRtrxvpValPeriodExt = timerfactory.Create<IPRtrxvpValPeriod>(_PRtrxvpValPeriod);

            return iPRtrxvpValPeriodExt;
        }
    }
}
