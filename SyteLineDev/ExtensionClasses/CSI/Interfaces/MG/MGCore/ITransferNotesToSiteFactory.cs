using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ITransferNotesToSiteFactory
    {
        ITransferNotesToSite Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}