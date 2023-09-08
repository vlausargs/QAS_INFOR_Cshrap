//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionUpdNewFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpPositionUpdNewFactory
    {
        public IEmpPositionUpdNew Create(IApplicationDB appDB)
        {
            var _EmpPositionUpdNew = new EmpPositionUpdNew(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpPositionUpdNewExt = timerfactory.Create<IEmpPositionUpdNew>(_EmpPositionUpdNew);

            return iEmpPositionUpdNewExt;
        }
    }
}
