using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IClearSessionFactory
    {
        IClearSession Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}