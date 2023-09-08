//PROJECT NAME: CSIVendor
//CLASS NAME: PoDelFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoDelFactory
	{
		public IPoDel Create(IApplicationDB appDB)
		{
			var _PoDel = new Logistics.Vendor.PoDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPoDelExt = timerfactory.Create<Logistics.Vendor.IPoDel>(_PoDel);
			
			return iPoDelExt;
		}
	}
}
