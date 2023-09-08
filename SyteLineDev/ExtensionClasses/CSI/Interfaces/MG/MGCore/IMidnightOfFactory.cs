using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IMidnightOfFactory
    {
        IMidnightOf Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}