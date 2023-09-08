//PROJECT NAME: Logistics
//CLASS NAME: Vendor360_GetOverviewValuesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class Vendor360_GetOverviewValuesFactory
	{
		public IVendor360_GetOverviewValues Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _Vendor360_GetOverviewValues = new Logistics.Vendor.Vendor360_GetOverviewValues(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendor360_GetOverviewValuesExt = timerfactory.Create<Logistics.Vendor.IVendor360_GetOverviewValues>(_Vendor360_GetOverviewValues);
			
			return iVendor360_GetOverviewValuesExt;
		}
	}
}
