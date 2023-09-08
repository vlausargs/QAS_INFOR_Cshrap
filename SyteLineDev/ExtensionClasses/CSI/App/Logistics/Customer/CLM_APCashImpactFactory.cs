//PROJECT NAME: CSICustomer
//CLASS NAME: CLM_APCashImpactFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_APCashImpactFactory
	{
		public ICLM_APCashImpact Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_APCashImpact = new Logistics.Customer.CLM_APCashImpact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_APCashImpactExt = timerfactory.Create<Logistics.Customer.ICLM_APCashImpact>(_CLM_APCashImpact);
			
			return iCLM_APCashImpactExt;
		}
	}
}
