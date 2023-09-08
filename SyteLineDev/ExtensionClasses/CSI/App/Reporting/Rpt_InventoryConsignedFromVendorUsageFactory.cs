//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InventoryConsignedFromVendorUsageFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InventoryConsignedFromVendorUsageFactory
	{
		public IRpt_InventoryConsignedFromVendorUsage Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InventoryConsignedFromVendorUsage = new Reporting.Rpt_InventoryConsignedFromVendorUsage(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InventoryConsignedFromVendorUsageExt = timerfactory.Create<Reporting.IRpt_InventoryConsignedFromVendorUsage>(_Rpt_InventoryConsignedFromVendorUsage);
			
			return iRpt_InventoryConsignedFromVendorUsageExt;
		}
	}
}
