using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetProcessVariableFactory
    {
        IGetProcessVariable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}