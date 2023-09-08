using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICstrFactory
    {
        ICstr Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}