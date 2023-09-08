//PROJECT NAME: CSIVendor
//CLASS NAME: GetAppmtsDefaultsForVendorFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAppmtsDefaultsForVendorFactory
	{
		public IGetAppmtsDefaultsForVendor Create(IApplicationDB appDB)
		{
			var _GetAppmtsDefaultsForVendor = new Logistics.Vendor.GetAppmtsDefaultsForVendor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAppmtsDefaultsForVendorExt = timerfactory.Create<Logistics.Vendor.IGetAppmtsDefaultsForVendor>(_GetAppmtsDefaultsForVendor);
			
			return iGetAppmtsDefaultsForVendorExt;
		}
	}
}
