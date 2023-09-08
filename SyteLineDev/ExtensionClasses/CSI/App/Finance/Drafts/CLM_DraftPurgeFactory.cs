//PROJECT NAME: CSIFinance
//CLASS NAME: CLM_DraftPurgeFactory.cs

using CSI.MG;

namespace CSI.Finance.Drafts
{
    public class CLM_DraftPurgeFactory
    {
        public ICLM_DraftPurge Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_DraftPurge = new CLM_DraftPurge(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLCustdrftsExt = timerfactory.Create<ICLM_DraftPurge>(_CLM_DraftPurge);

            return iSLCustdrftsExt;
        }
    }
}
