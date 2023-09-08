//PROJECT NAME: Logistics
//CLASS NAME: VendorCustomerValidationFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class VendorCustomerValidationFactory
	{
		public IVendorCustomerValidation Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _VendorCustomerValidation = new Logistics.Vendor.VendorCustomerValidation(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendorCustomerValidationExt = timerfactory.Create<Logistics.Vendor.IVendorCustomerValidation>(_VendorCustomerValidation);
			
			return iVendorCustomerValidationExt;
		}
	}
}
