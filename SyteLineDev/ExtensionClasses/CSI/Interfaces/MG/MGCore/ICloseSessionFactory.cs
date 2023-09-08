using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICloseSessionFactory
    {
        ICloseSession Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}