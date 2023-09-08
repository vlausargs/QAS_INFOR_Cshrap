using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IUserNameBySessionIdFactory
    {
        IUserNameBySessionId Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}