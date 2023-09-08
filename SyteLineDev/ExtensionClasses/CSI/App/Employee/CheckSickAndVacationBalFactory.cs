//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckSickAndVacationBalFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CheckSickAndVacationBalFactory
    {
        public ICheckSickAndVacationBal Create(IApplicationDB appDB)
        {
            var _CheckSickAndVacationBal = new CheckSickAndVacationBal(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckSickAndVacationBalExt = timerfactory.Create<ICheckSickAndVacationBal>(_CheckSickAndVacationBal);

            return iCheckSickAndVacationBalExt;
        }
    }
}
