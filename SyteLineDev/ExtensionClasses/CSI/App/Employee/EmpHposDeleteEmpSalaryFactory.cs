//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpHposDeleteEmpSalaryFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpHposDeleteEmpSalaryFactory
    {
        public IEmpHposDeleteEmpSalary Create(IApplicationDB appDB)
        {
            var _EmpHposDeleteEmpSalary = new EmpHposDeleteEmpSalary(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpHposDeleteEmpSalaryExt = timerfactory.Create<IEmpHposDeleteEmpSalary>(_EmpHposDeleteEmpSalary);

            return iEmpHposDeleteEmpSalaryExt;
        }
    }
}
