using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IDoubleQuoteFactory
    {
        IDoubleQuote Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}