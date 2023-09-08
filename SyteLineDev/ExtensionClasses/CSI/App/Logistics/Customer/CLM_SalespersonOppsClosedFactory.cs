//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalespersonOppsClosedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SalespersonOppsClosedFactory
	{
		public ICLM_SalespersonOppsClosed Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SalespersonOppsClosed = new Logistics.Customer.CLM_SalespersonOppsClosed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SalespersonOppsClosedExt = timerfactory.Create<Logistics.Customer.ICLM_SalespersonOppsClosed>(_CLM_SalespersonOppsClosed);
			
			return iCLM_SalespersonOppsClosedExt;
		}
	}
}
