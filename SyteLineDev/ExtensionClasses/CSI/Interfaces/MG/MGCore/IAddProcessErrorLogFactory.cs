using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IAddProcessErrorLogFactory
    {
        IAddProcessErrorLog Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}