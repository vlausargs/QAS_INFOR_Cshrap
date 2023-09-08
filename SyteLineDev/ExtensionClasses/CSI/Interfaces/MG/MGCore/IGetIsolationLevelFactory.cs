using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetIsolationLevelFactory
    {
        IGetIsolationLevel Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}