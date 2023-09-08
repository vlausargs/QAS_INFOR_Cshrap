//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXVendorPckSlipHdrLoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class SSSRMXVendorPckSlipHdrLoadFactory
	{
		public ISSSRMXVendorPckSlipHdrLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXVendorPckSlipHdrLoad = new Logistics.Customer.SSSRMXVendorPckSlipHdrLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXVendorPckSlipHdrLoadExt = timerfactory.Create<Logistics.Customer.ISSSRMXVendorPckSlipHdrLoad>(_SSSRMXVendorPckSlipHdrLoad);
			
			return iSSSRMXVendorPckSlipHdrLoadExt;
		}
	}
}
