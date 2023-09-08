using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IInitSessionContextFactory
    {
        IInitSessionContext Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}