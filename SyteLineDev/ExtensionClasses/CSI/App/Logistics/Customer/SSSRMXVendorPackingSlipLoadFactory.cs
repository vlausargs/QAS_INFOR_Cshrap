//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXVendorPackingSlipLoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class SSSRMXVendorPackingSlipLoadFactory
	{
		public ISSSRMXVendorPackingSlipLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXVendorPackingSlipLoad = new Logistics.Customer.SSSRMXVendorPackingSlipLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXVendorPackingSlipLoadExt = timerfactory.Create<Logistics.Customer.ISSSRMXVendorPackingSlipLoad>(_SSSRMXVendorPackingSlipLoad);
			
			return iSSSRMXVendorPackingSlipLoadExt;
		}
	}
}
