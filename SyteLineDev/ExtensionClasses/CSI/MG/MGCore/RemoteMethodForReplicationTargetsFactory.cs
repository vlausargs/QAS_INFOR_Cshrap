//PROJECT NAME: MG.MGCore
//CLASS NAME: RemoteMethodForReplicationTargetsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.MG.MGCore
{
    public class RemoteMethodForReplicationTargetsFactory : IRemoteMethodForReplicationTargetsFactory
    {
        public IRemoteMethodForReplicationTargets Create(IApplicationDB appDB,
        IBunchedLoadCollection bunchedLoadCollection,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
            var _RemoteMethodForReplicationTargets = new RemoteMethodForReplicationTargets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRemoteMethodForReplicationTargetsExt = timerfactory.Create<MG.MGCore.IRemoteMethodForReplicationTargets>(_RemoteMethodForReplicationTargets);

            return iRemoteMethodForReplicationTargetsExt;
        }
    }
}
