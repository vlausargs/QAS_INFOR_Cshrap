using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IResetSessionIDFactory
    {
        IResetSessionID Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}