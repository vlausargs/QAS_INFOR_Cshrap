//PROJECT NAME: CSIAdmin
//CLASS NAME: DBTaskFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class DBTaskFactory
    {
        public IDBTask Create(IApplicationDB appDB, IMGInvoker mgInvoker, bool isCloud)
        {
            var _DBTask = new DBTask(appDB, mgInvoker, isCloud);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iDBTaskExt = timerfactory.Create<IDBTask>(_DBTask);

            return iDBTaskExt;
        }
    }
}
