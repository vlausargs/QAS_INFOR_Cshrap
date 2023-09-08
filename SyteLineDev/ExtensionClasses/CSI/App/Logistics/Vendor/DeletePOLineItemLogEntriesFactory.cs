//PROJECT NAME: CSIVendor
//CLASS NAME: DeletePOLineItemLogEntriesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DeletePOLineItemLogEntriesFactory
	{
		public IDeletePOLineItemLogEntries Create(IApplicationDB appDB)
		{
			var _DeletePOLineItemLogEntries = new Logistics.Vendor.DeletePOLineItemLogEntries(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDeletePOLineItemLogEntriesExt = timerfactory.Create<Logistics.Vendor.IDeletePOLineItemLogEntries>(_DeletePOLineItemLogEntries);
			
			return iDeletePOLineItemLogEntriesExt;
		}
	}
}
