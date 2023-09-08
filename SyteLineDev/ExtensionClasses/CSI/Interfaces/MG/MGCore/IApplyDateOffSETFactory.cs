using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IApplyDateOffsetFactory
    {
        IApplyDateOffset Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}