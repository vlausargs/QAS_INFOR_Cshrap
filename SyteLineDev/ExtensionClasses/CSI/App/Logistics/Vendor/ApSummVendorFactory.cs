//PROJECT NAME: CSIVendor
//CLASS NAME: ApSummVendorFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class ApSummVendorFactory
	{
		public IApSummVendor Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ApSummVendor = new Logistics.Vendor.ApSummVendor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApSummVendorExt = timerfactory.Create<Logistics.Vendor.IApSummVendor>(_ApSummVendor);
			
			return iApSummVendorExt;
		}
	}
}
