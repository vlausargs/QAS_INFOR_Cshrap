//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIPOAckInboundFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIPOAckInboundFactory
	{
		public IPurgeEDIPOAckInbound Create(IApplicationDB appDB)
		{
			var _PurgeEDIPOAckInbound = new Logistics.Vendor.PurgeEDIPOAckInbound(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIPOAckInboundExt = timerfactory.Create<Logistics.Vendor.IPurgeEDIPOAckInbound>(_PurgeEDIPOAckInbound);
			
			return iPurgeEDIPOAckInboundExt;
		}
	}
}
