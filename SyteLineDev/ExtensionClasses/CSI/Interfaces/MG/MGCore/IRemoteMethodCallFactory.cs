using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IRemoteMethodCallFactory
    {
        IRemoteMethodCall Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}