using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IUserName2Factory
    {
        IUserName2 Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}