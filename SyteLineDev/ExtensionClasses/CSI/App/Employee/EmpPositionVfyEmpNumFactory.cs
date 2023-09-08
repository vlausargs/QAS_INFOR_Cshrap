//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionVfyEmpNumFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpPositionVfyEmpNumFactory
    {
        public IEmpPositionVfyEmpNum Create(IApplicationDB appDB)
        {
            var _EmpPositionVfyEmpNum = new EmpPositionVfyEmpNum(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpPositionVfyEmpNumExt = timerfactory.Create<IEmpPositionVfyEmpNum>(_EmpPositionVfyEmpNum);

            return iEmpPositionVfyEmpNumExt;
        }
    }
}
