using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface ISetSiteFactory
    {
        ISetSite Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}