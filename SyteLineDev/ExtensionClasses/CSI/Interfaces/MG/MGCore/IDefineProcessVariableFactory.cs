using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDefineProcessVariableFactory
    {
        IDefineProcessVariable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}