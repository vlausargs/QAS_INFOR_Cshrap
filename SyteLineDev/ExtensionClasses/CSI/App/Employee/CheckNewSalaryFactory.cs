//PROJECT NAME: CSIEmployee
//CLASS NAME: CheckNewSalaryFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CheckNewSalaryFactory
    {
        public ICheckNewSalary Create(IApplicationDB appDB)
        {
            var _CheckNewSalary = new CheckNewSalary(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCheckNewSalaryExt = timerfactory.Create<ICheckNewSalary>(_CheckNewSalary);

            return iCheckNewSalaryExt;
        }
    }
}
