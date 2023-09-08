//PROJECT NAME: Logistics
//CLASS NAME: THAGetTaxAcctsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetTaxAcctsFactory
	{
		public ITHAGetTaxAccts Create(IApplicationDB appDB)
		{
			var _THAGetTaxAccts = new Logistics.Vendor.THAGetTaxAccts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAGetTaxAcctsExt = timerfactory.Create<Logistics.Vendor.ITHAGetTaxAccts>(_THAGetTaxAccts);
			
			return iTHAGetTaxAcctsExt;
		}
	}
}
