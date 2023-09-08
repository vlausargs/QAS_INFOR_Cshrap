//PROJECT NAME: CSIVendor
//CLASS NAME: APEndFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class APEndFactory
	{
		public IAPEnd Create(IApplicationDB appDB)
		{
			var _APEnd = new Logistics.Vendor.APEnd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAPEndExt = timerfactory.Create<Logistics.Vendor.IAPEnd>(_APEnd);
			
			return iAPEndExt;
		}
	}
}
