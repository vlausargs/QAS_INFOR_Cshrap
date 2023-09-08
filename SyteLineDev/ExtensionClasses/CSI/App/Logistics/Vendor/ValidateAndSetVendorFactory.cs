//PROJECT NAME: Logistics
//CLASS NAME: ValidateAndSetVendorFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ValidateAndSetVendorFactory
	{
		public IValidateAndSetVendor Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ValidateAndSetVendor = new Logistics.Vendor.ValidateAndSetVendor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateAndSetVendorExt = timerfactory.Create<Logistics.Vendor.IValidateAndSetVendor>(_ValidateAndSetVendor);
			
			return iValidateAndSetVendorExt;
		}
	}
}
