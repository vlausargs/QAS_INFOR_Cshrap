using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ICloseSessionContextFactory
    {
        ICloseSessionContext Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}