//PROJECT NAME: Logistics
//CLASS NAME: IsVendorStatusDeactivationValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class IsVendorStatusDeactivationValidFactory
	{
		public IIsVendorStatusDeactivationValid Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _IsVendorStatusDeactivationValid = new Logistics.Vendor.IsVendorStatusDeactivationValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsVendorStatusDeactivationValidExt = timerfactory.Create<Logistics.Vendor.IIsVendorStatusDeactivationValid>(_IsVendorStatusDeactivationValid);
			
			return iIsVendorStatusDeactivationValidExt;
		}
	}
}
