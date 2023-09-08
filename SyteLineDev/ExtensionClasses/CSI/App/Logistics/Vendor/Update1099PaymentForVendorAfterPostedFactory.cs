//PROJECT NAME: Logistics
//CLASS NAME: Update1099PaymentForVendorAfterPostedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class Update1099PaymentForVendorAfterPostedFactory
	{
		public IUpdate1099PaymentForVendorAfterPosted Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _Update1099PaymentForVendorAfterPosted = new Logistics.Vendor.Update1099PaymentForVendorAfterPosted(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdate1099PaymentForVendorAfterPostedExt = timerfactory.Create<Logistics.Vendor.IUpdate1099PaymentForVendorAfterPosted>(_Update1099PaymentForVendorAfterPosted);
			
			return iUpdate1099PaymentForVendorAfterPostedExt;
		}
	}
}
