//PROJECT NAME: CSIEmployee
//CLASS NAME: CLM_ProcessMgrProcessFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class CLM_ProcessMgrProcessFactory
    {
        public ICLM_ProcessMgrProcess Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ProcessMgrProcess = new CLM_ProcessMgrProcess(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ProcessMgrProcessExt = timerfactory.Create<ICLM_ProcessMgrProcess>(_CLM_ProcessMgrProcess);

            return iCLM_ProcessMgrProcessExt;
        }
    }
}
