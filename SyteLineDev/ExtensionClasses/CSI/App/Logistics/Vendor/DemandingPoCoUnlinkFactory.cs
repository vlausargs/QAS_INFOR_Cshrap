//PROJECT NAME: CSIVendor
//CLASS NAME: DemandingPoCoUnlinkFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DemandingPoCoUnlinkFactory
	{
		public IDemandingPoCoUnlink Create(IApplicationDB appDB)
		{
			var _DemandingPoCoUnlink = new Logistics.Vendor.DemandingPoCoUnlink(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDemandingPoCoUnlinkExt = timerfactory.Create<Logistics.Vendor.IDemandingPoCoUnlink>(_DemandingPoCoUnlink);
			
			return iDemandingPoCoUnlinkExt;
		}
	}
}
