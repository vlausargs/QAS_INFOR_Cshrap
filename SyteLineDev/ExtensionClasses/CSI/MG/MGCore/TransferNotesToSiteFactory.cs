//PROJECT NAME: MG.MGCore
//CLASS NAME: TransferNotesToSiteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.MG.MGCore
{
    public class TransferNotesToSiteFactory : ITransferNotesToSiteFactory
    {
        public ITransferNotesToSite Create(IApplicationDB appDB,
        IMGInvoker mgInvoker,
        IParameterProvider parameterProvider,
        bool calledFromIDO)
        {
            var _TransferNotesToSite = new TransferNotesToSite(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTransferNotesToSiteExt = timerfactory.Create<MG.MGCore.ITransferNotesToSite>(_TransferNotesToSite);

            return iTransferNotesToSiteExt;
        }
    }
}
