//PROJECT NAME: MG.MGCore
//CLASS NAME: RemoteInfobarSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class RemoteInfobarSaveFactory : IRemoteInfobarSaveFactory
    {
        public IRemoteInfobarSave Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _RemoteInfobarSave = new RemoteInfobarSave(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRemoteInfobarSaveExt = timerfactory.Create<MG.MGCore.IRemoteInfobarSave>(_RemoteInfobarSave);

            return iRemoteInfobarSaveExt;
        }
    }
}
