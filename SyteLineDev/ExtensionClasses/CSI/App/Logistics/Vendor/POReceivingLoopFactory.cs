//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingLoopFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceivingLoopFactory
	{
		public IPOReceivingLoop Create(IApplicationDB appDB)
		{
			var _POReceivingLoop = new Logistics.Vendor.POReceivingLoop(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceivingLoopExt = timerfactory.Create<Logistics.Vendor.IPOReceivingLoop>(_POReceivingLoop);
			
			return iPOReceivingLoopExt;
		}
	}
}
