using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IVariableIsDefinedFactory
    {
        IVariableIsDefined Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}