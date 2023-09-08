//PROJECT NAME: CSIEmployee
//CLASS NAME: EmployeeSalaryPeriodFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmployeeSalaryPeriodFactory
    {
        public IEmployeeSalaryPeriod Create(IApplicationDB appDB)
        {
            var _EmployeeSalaryPeriod = new EmployeeSalaryPeriod(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmployeeSalaryPeriodExt = timerfactory.Create<IEmployeeSalaryPeriod>(_EmployeeSalaryPeriod);

            return iEmployeeSalaryPeriodExt;
        }
    }
}
