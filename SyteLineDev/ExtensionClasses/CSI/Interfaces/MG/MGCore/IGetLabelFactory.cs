using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetLabelFactory
    {
        IGetLabel Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}