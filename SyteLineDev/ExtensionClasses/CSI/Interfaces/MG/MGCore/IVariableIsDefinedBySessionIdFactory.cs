using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IVariableIsDefinedBySessionIdFactory
    {
        IVariableIsDefinedBySessionId Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}