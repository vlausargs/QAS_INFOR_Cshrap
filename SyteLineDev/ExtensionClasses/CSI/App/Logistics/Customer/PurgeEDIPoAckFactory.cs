//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIPoAckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIPoAckFactory
	{
		public IPurgeEDIPoAck Create(IApplicationDB appDB)
		{
			var _PurgeEDIPoAck = new Logistics.Customer.PurgeEDIPoAck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIPoAckExt = timerfactory.Create<Logistics.Customer.IPurgeEDIPoAck>(_PurgeEDIPoAck);
			
			return iPurgeEDIPoAckExt;
		}
	}
}
