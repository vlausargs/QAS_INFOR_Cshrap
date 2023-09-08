//PROJECT NAME: Logistics
//CLASS NAME: THAGetPurcAcctFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetPurcAcctFactory
	{
		public ITHAGetPurcAcct Create(IApplicationDB appDB)
		{
			var _THAGetPurcAcct = new Logistics.Vendor.THAGetPurcAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAGetPurcAcctExt = timerfactory.Create<Logistics.Vendor.ITHAGetPurcAcct>(_THAGetPurcAcct);
			
			return iTHAGetPurcAcctExt;
		}
	}
}
