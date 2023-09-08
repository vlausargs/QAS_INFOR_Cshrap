//PROJECT NAME: CSIVendor
//CLASS NAME: PoExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoExistsFactory
	{
		public IPoExists Create(IApplicationDB appDB)
		{
			var _PoExists = new Logistics.Vendor.PoExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoExistsExt = timerfactory.Create<Logistics.Vendor.IPoExists>(_PoExists);
			
			return iPoExistsExt;
		}
	}
}
