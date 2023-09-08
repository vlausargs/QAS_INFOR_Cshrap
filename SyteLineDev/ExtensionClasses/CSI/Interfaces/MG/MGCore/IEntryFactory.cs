using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IEntryFactory
    {
        IEntry Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}