using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISessionIDFactory
    {
        ISessionID Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}