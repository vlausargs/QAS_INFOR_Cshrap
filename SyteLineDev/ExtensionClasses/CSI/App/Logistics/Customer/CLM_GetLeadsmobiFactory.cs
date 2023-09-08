//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetLeadsmobiFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetLeadsmobiFactory
	{
		public ICLM_GetLeadsmobi Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetLeadsmobi = new Logistics.Customer.CLM_GetLeadsmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetLeadsmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetLeadsmobi>(_CLM_GetLeadsmobi);
			
			return iCLM_GetLeadsmobiExt;
		}
	}
}
