//PROJECT NAME: CSIVendor
//CLASS NAME: GrnDelUtilFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GrnDelUtilFactory
	{
		public IGrnDelUtil Create(IApplicationDB appDB)
		{
			var _GrnDelUtil = new Logistics.Vendor.GrnDelUtil(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGrnDelUtilExt = timerfactory.Create<Logistics.Vendor.IGrnDelUtil>(_GrnDelUtil);
			
			return iGrnDelUtilExt;
		}
	}
}
