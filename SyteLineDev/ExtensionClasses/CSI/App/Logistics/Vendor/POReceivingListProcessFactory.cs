//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingListProcessFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class POReceivingListProcessFactory
	{
		public IPOReceivingListProcess Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _POReceivingListProcess = new Logistics.Vendor.POReceivingListProcess(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivingListProcessExt = timerfactory.Create<Logistics.Vendor.IPOReceivingListProcess>(_POReceivingListProcess);
			
			return iPOReceivingListProcessExt;
		}
	}
}
