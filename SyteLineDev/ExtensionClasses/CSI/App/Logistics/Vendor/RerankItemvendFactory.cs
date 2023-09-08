//PROJECT NAME: Logistics
//CLASS NAME: RerankItemvendFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class RerankItemvendFactory
	{
		public IRerankItemvend Create(IApplicationDB appDB)
		{
			var _RerankItemvend = new Logistics.Vendor.RerankItemvend(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRerankItemvendExt = timerfactory.Create<Logistics.Vendor.IRerankItemvend>(_RerankItemvend);
			
			return iRerankItemvendExt;
		}
	}
}
