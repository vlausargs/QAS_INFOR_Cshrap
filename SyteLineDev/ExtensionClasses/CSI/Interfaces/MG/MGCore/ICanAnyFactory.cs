using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICanAnyFactory
    {
        ICanAny Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}