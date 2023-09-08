using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IRestoreTriggerStateFactory
    {
        IRestoreTriggerState Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}