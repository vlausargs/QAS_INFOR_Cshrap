//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_CoItemsBacklogFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_CoItemsBacklogFactory
	{
		public ICLM_CoItemsBacklog Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_CoItemsBacklog = new Logistics.Customer.CLM_CoItemsBacklog(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_CoItemsBacklogExt = timerfactory.Create<Logistics.Customer.ICLM_CoItemsBacklog>(_CLM_CoItemsBacklog);
			
			return iCLM_CoItemsBacklogExt;
		}
	}
}
