//PROJECT NAME: CSIVendor
//CLASS NAME: Home_GetTodaysKeyVendorValuesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Home_GetTodaysKeyVendorValuesFactory
	{
		public IHome_GetTodaysKeyVendorValues Create(IApplicationDB appDB)
		{
			var _Home_GetTodaysKeyVendorValues = new Logistics.Vendor.Home_GetTodaysKeyVendorValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_GetTodaysKeyVendorValuesExt = timerfactory.Create<Logistics.Vendor.IHome_GetTodaysKeyVendorValues>(_Home_GetTodaysKeyVendorValues);
			
			return iHome_GetTodaysKeyVendorValuesExt;
		}
	}
}
