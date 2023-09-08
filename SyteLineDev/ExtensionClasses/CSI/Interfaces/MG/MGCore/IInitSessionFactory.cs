using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IInitSessionFactory
    {
        IInitSession Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}