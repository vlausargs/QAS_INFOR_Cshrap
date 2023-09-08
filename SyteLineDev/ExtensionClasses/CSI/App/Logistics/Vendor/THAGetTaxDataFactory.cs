//PROJECT NAME: Logistics
//CLASS NAME: THAGetTaxDataFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class THAGetTaxDataFactory
	{
		public ITHAGetTaxData Create(IApplicationDB appDB)
		{
			var _THAGetTaxData = new Logistics.Vendor.THAGetTaxData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHAGetTaxDataExt = timerfactory.Create<Logistics.Vendor.ITHAGetTaxData>(_THAGetTaxData);
			
			return iTHAGetTaxDataExt;
		}
	}
}
