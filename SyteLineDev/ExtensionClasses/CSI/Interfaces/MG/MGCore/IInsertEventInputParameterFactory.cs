using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IInsertEventInputParameterFactory
    {
        IInsertEventInputParameter Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}