//PROJECT NAME: CSIEmployee
//CLASS NAME: ACAResetCorrectedEmployeesFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ACAResetCorrectedEmployeesFactory
    {
        public IACAResetCorrectedEmployees Create(IApplicationDB appDB)
        {
            var _ACAResetCorrectedEmployees = new Employee.ACAResetCorrectedEmployees(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iACAResetCorrectedEmployeesExt = timerfactory.Create<Employee.IACAResetCorrectedEmployees>(_ACAResetCorrectedEmployees);

            return iACAResetCorrectedEmployeesExt;
        }
    }
}
