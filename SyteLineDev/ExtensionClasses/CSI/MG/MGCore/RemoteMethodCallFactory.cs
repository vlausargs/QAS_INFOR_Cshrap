//PROJECT NAME: MG.MGCore
//CLASS NAME: RemoteMethodCallFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.MG.MGCore
{
    public class RemoteMethodCallFactory : IRemoteMethodCallFactory
    {
        public IRemoteMethodCall Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _RemoteMethodCall = new MG.MGCore.RemoteMethodCall(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRemoteMethodCallExt = timerfactory.Create<MG.MGCore.IRemoteMethodCall>(_RemoteMethodCall);

            return iRemoteMethodCallExt;
        }
    }
}
