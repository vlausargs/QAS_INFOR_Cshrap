//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_DirectDebitPurgeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_DirectDebitPurgeFactory
    {
        public ICLM_DirectDebitPurge Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_DirectDebitPurge = new CLM_DirectDebitPurge(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_DirectDebitPurgeExt = timerfactory.Create<ICLM_DirectDebitPurge>(_CLM_DirectDebitPurge);

            return iCLM_DirectDebitPurgeExt;
        }
    }
}
