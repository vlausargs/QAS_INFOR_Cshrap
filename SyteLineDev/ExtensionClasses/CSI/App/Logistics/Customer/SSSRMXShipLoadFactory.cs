//PROJECT NAME: Logistics
//CLASS NAME: SSSRMXShipLoadFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class SSSRMXShipLoadFactory
	{
		public ISSSRMXShipLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRMXShipLoad = new Logistics.Customer.SSSRMXShipLoad(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRMXShipLoadExt = timerfactory.Create<Logistics.Customer.ISSSRMXShipLoad>(_SSSRMXShipLoad);
			
			return iSSSRMXShipLoadExt;
		}
	}
}
