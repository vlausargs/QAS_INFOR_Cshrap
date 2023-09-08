//PROJECT NAME: CSIAdmin
//CLASS NAME: GetLockedDBObjectsFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class GetLockedDBObjectsFactory
    {
        public IGetLockedDBObjects Create(IApplicationDB appDB)
        {
            var _GetLockedDBObjects = new GetLockedDBObjects(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iGetLockedDBObjectsExt = timerfactory.Create<IGetLockedDBObjects>(_GetLockedDBObjects);

            return iGetLockedDBObjectsExt;
        }
    }
}

