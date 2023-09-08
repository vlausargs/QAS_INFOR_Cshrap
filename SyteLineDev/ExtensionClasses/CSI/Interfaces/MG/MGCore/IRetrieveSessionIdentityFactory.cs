using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IRetrieveSessionIdentityFactory
    {
        IRetrieveSessionIdentity Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}