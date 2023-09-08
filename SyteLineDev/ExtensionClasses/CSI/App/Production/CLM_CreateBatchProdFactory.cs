//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_CreateBatchProdFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CLM_CreateBatchProdFactory
    {
        public ICLM_CreateBatchProd Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_CreateBatchProd = new CLM_CreateBatchProd(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_CreateBatchProdExt = timerfactory.Create<ICLM_CreateBatchProd>(_CLM_CreateBatchProd);

            return iCLM_CreateBatchProdExt;
        }
    }
}
