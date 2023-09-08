using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IFireEventFactory
    {
        IFireEvent Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}