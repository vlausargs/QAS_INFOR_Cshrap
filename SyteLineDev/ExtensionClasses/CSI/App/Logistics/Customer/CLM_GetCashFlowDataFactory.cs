//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetCashFlowDataFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class CLM_GetCashFlowDataFactory
    {
        public ICLM_GetCashFlowData Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _CLM_GetCashFlowData = new Customer.CLM_GetCashFlowData(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iCLM_GetCashFlowDataExt = timerfactory.Create<Customer.ICLM_GetCashFlowData>(_CLM_GetCashFlowData);

            return iCLM_GetCashFlowDataExt;
        }
    }
}
