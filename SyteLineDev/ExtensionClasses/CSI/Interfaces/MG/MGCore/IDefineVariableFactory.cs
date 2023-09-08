using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDefineVariableFactory
    {
        IDefineVariable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}