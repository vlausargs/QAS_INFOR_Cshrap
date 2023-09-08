using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetVariableFactory
    {
        IGetVariable Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}