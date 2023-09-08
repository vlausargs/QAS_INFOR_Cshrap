using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICopySessionVariablesFactory
    {
        ICopySessionVariables Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}