//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CashImpactGraphFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_CashImpactGraphFactory
    {
        public ICLM_CashImpactGraph Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_CashImpactGraph = new Customer.CLM_CashImpactGraph(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_CashImpactGraphExt = timerfactory.Create<Customer.ICLM_CashImpactGraph>(_CLM_CashImpactGraph);

            return iCLM_CashImpactGraphExt;
        }
    }
}
