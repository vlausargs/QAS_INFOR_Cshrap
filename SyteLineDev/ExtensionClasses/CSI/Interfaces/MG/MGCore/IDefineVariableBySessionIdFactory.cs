using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDefineVariableBySessionIdFactory
    {
        IDefineVariableBySessionId Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}