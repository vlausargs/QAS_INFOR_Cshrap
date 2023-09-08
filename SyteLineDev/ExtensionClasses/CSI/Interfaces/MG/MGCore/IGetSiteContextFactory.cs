using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public interface IGetSiteContextFactory
    {
        IGetSiteContext Create(IApplicationDB appDB, IMGInvoker mgInvoker, IParameterProvider parameterProvider, bool calledFromIDO);
    }
}