//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIASNFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIASNFactory
	{
		public IPurgeEDIASN Create(IApplicationDB appDB)
		{
			var _PurgeEDIASN = new Logistics.Customer.PurgeEDIASN(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIASNExt = timerfactory.Create<Logistics.Customer.IPurgeEDIASN>(_PurgeEDIASN);
			
			return iPurgeEDIASNExt;
		}
	}
}
