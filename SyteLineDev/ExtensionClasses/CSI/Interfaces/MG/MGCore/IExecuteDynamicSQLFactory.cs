using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IExecuteDynamicSQLFactory
    {
        IExecuteDynamicSQL Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}