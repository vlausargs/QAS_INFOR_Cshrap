using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISetTriggerStateFactory
    {
        ISetTriggerState Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}