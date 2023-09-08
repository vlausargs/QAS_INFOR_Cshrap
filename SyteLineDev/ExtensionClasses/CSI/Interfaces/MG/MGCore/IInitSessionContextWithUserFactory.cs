using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IInitSessionContextWithUserFactory
    {
        IInitSessionContextWithUser Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}