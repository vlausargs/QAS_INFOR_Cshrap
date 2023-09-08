//PROJECT NAME: CSIEmployee
//CLASS NAME: EmpPositionVfyJobFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class EmpPositionVfyJobFactory
    {
        public IEmpPositionVfyJob Create(IApplicationDB appDB)
        {
            var _EmpPositionVfyJob = new EmpPositionVfyJob(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEmpPositionVfyJobExt = timerfactory.Create<IEmpPositionVfyJob>(_EmpPositionVfyJob);

            return iEmpPositionVfyJobExt;
        }
    }
}
