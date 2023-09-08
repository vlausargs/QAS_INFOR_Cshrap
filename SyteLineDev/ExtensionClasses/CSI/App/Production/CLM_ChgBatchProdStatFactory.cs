//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_ChgBatchProdStatFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CLM_ChgBatchProdStatFactory
    {
        public ICLM_ChgBatchProdStat Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_ChgBatchProdStat = new CLM_ChgBatchProdStat(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_ChgBatchProdStatExt = timerfactory.Create<ICLM_ChgBatchProdStat>(_CLM_ChgBatchProdStat);

            return iCLM_ChgBatchProdStatExt;
        }
    }
}
