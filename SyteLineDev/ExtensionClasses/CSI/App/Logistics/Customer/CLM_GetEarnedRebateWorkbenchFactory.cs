//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetEarnedRebateWorkbenchFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetEarnedRebateWorkbenchFactory
	{
		public ICLM_GetEarnedRebateWorkbench Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetEarnedRebateWorkbench = new Logistics.Customer.CLM_GetEarnedRebateWorkbench(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetEarnedRebateWorkbenchExt = timerfactory.Create<Logistics.Customer.ICLM_GetEarnedRebateWorkbench>(_CLM_GetEarnedRebateWorkbench);
			
			return iCLM_GetEarnedRebateWorkbenchExt;
		}
	}
}
