using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IUndefineVariableBySessionIdFactory
    {
        IUndefineVariableBySessionId Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}