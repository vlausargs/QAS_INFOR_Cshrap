//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_GetOppsmobiFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_GetOppsmobiFactory
	{
		public ICLM_GetOppsmobi Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetOppsmobi = new Logistics.Customer.CLM_GetOppsmobi(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetOppsmobiExt = timerfactory.Create<Logistics.Customer.ICLM_GetOppsmobi>(_CLM_GetOppsmobi);
			
			return iCLM_GetOppsmobiExt;
		}
	}
}
