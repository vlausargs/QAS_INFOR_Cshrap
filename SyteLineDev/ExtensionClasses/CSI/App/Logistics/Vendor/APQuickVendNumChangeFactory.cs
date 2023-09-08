//PROJECT NAME: CSIVendor
//CLASS NAME: APQuickVendNumChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APQuickVendNumChangeFactory
	{
		public IAPQuickVendNumChange Create(IApplicationDB appDB)
		{
			var _APQuickVendNumChange = new Logistics.Vendor.APQuickVendNumChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPQuickVendNumChangeExt = timerfactory.Create<Logistics.Vendor.IAPQuickVendNumChange>(_APQuickVendNumChange);
			
			return iAPQuickVendNumChangeExt;
		}
	}
}
