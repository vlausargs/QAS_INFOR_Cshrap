//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_RemoveBatchProdFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class CLM_RemoveBatchProdFactory
    {
        public ICLM_RemoveBatchProd Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_RemoveBatchProd = new CLM_RemoveBatchProd(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_RemoveBatchProdExt = timerfactory.Create<ICLM_RemoveBatchProd>(_CLM_RemoveBatchProd);

            return iCLM_RemoveBatchProdExt;
        }
    }
}
