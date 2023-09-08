//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_PurchasingCashImpactFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_PurchasingCashImpactFactory
	{
		public ICLM_PurchasingCashImpact Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_PurchasingCashImpact = new Logistics.Vendor.CLM_PurchasingCashImpact(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_PurchasingCashImpactExt = timerfactory.Create<Logistics.Vendor.ICLM_PurchasingCashImpact>(_CLM_PurchasingCashImpact);
			
			return iCLM_PurchasingCashImpactExt;
		}
	}
}
