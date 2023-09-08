using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IRemoteMethodForReplicationTargetsFactory
    {
        IRemoteMethodForReplicationTargets Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}