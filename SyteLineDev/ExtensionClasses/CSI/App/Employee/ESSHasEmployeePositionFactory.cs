//PROJECT NAME: CSIEmployee
//CLASS NAME: ESSHasEmployeePositionFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class ESSHasEmployeePositionFactory
    {
        public IESSHasEmployeePosition Create(IApplicationDB appDB)
        {
            var _ESSHasEmployeePosition = new Employee.ESSHasEmployeePosition(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iESSHasEmployeePositionExt = timerfactory.Create<Employee.IESSHasEmployeePosition>(_ESSHasEmployeePosition);

            return iESSHasEmployeePositionExt;
        }
    }
}
