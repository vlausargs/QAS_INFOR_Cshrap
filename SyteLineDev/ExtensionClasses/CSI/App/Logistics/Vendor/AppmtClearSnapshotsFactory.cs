//PROJECT NAME: CSIVendor
//CLASS NAME: AppmtClearSnapshotsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AppmtClearSnapshotsFactory
	{
		public IAppmtClearSnapshots Create(IApplicationDB appDB)
		{
			var _AppmtClearSnapshots = new Logistics.Vendor.AppmtClearSnapshots(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtClearSnapshotsExt = timerfactory.Create<Logistics.Vendor.IAppmtClearSnapshots>(_AppmtClearSnapshots);
			
			return iAppmtClearSnapshotsExt;
		}
	}
}
