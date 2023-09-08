//PROJECT NAME: Logistics
//CLASS NAME: IsVendorActiveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class IsVendorActiveFactory
	{
		public IIsVendorActive Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _IsVendorActive = new Logistics.Vendor.IsVendorActive(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsVendorActiveExt = timerfactory.Create<Logistics.Vendor.IIsVendorActive>(_IsVendorActive);
			
			return iIsVendorActiveExt;
		}
	}
}
