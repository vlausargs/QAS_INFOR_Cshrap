//PROJECT NAME: CSIVendor
//CLASS NAME: POReceiveUMChangedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceiveUMChangedFactory
	{
		public IPOReceiveUMChanged Create(IApplicationDB appDB)
		{
			var _POReceiveUMChanged = new Logistics.Vendor.POReceiveUMChanged(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceiveUMChangedExt = timerfactory.Create<Logistics.Vendor.IPOReceiveUMChanged>(_POReceiveUMChanged);
			
			return iPOReceiveUMChangedExt;
		}
	}
}
