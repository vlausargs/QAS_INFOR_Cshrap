//PROJECT NAME: CSICodes
//CLASS NAME: CLM_LedgerDimSubCollectionFactory.cs

using CSI.MG;

namespace CSI.Codes
{
    public class CLM_LedgerDimSubCollectionFactory
    {
        public ICLM_LedgerDimSubCollection Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_LedgerDimSubCollection = new CLM_LedgerDimSubCollection(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_LedgerDimSubCollectionExt = timerfactory.Create<ICLM_LedgerDimSubCollection>(_CLM_LedgerDimSubCollection);

            return iCLM_LedgerDimSubCollectionExt;
        }
    }
}
