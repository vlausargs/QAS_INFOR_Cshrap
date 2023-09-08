//PROJECT NAME: CSIEmployee
//CLASS NAME: GetDefaultPayRateFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class GetDefaultPayRateFactory
    {
        public IGetDefaultPayRate Create(IApplicationDB appDB)
        {
            var _GetDefaultPayRate = new GetDefaultPayRate(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetDefaultPayRateExt = timerfactory.Create<IGetDefaultPayRate>(_GetDefaultPayRate);

            return iGetDefaultPayRateExt;
        }
    }
}
