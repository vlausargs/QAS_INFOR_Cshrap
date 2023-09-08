//PROJECT NAME: Logistics
//CLASS NAME: IsVendorDeactivationValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class IsVendorDeactivationValidFactory
	{
		public IIsVendorDeactivationValid Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _IsVendorDeactivationValid = new Logistics.Vendor.IsVendorDeactivationValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsVendorDeactivationValidExt = timerfactory.Create<Logistics.Vendor.IIsVendorDeactivationValid>(_IsVendorDeactivationValid);
			
			return iIsVendorDeactivationValidExt;
		}
	}
}
