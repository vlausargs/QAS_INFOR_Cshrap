using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IAnticipateSessionIdentityFactory
    {
        IAnticipateSessionIdentity Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}