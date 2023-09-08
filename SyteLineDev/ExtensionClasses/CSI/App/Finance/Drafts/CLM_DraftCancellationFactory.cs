//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_DraftCancellationFactory.cs

using CSI.MG;

namespace CSI.Finance.Drafts
{
    public class CLM_DraftCancellationFactory
    {
        public ICLM_DraftCancellation Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_DraftCancellation = new CLM_DraftCancellation(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<ICLM_DraftCancellation>(_CLM_DraftCancellation);

            return iSLCustdrftsExt;
        }
    }
}