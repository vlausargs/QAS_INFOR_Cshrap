//PROJECT NAME: CSIEmployee
//CLASS NAME: MarkProMgrMyTaskStateFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class MarkProMgrMyTaskStateFactory
    {
        public IMarkProMgrMyTaskState Create(IApplicationDB appDB)
        {
            var _MarkProMgrMyTaskState = new MarkProMgrMyTaskState(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iMarkProMgrMyTaskStateExt = timerfactory.Create<IMarkProMgrMyTaskState>(_MarkProMgrMyTaskState);

            return iMarkProMgrMyTaskStateExt;
        }
    }
}
