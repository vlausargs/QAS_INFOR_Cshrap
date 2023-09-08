using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISetNextKeyFactory
    {
        ISetNextKey Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}