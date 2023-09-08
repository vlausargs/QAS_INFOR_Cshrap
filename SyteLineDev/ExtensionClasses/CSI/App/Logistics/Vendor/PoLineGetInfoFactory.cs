//PROJECT NAME: CSIVendor
//CLASS NAME: PoLineGetInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoLineGetInfoFactory
	{
		public IPoLineGetInfo Create(IApplicationDB appDB)
		{
			var _PoLineGetInfo = new Logistics.Vendor.PoLineGetInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoLineGetInfoExt = timerfactory.Create<Logistics.Vendor.IPoLineGetInfo>(_PoLineGetInfo);
			
			return iPoLineGetInfoExt;
		}
	}
}
