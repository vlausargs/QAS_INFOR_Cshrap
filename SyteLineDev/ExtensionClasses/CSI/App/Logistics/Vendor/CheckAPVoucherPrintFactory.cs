//PROJECT NAME: Logistics
//CLASS NAME: CheckAPVoucherPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CheckAPVoucherPrintFactory
	{
		public ICheckAPVoucherPrint Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _CheckAPVoucherPrint = new Logistics.Vendor.CheckAPVoucherPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckAPVoucherPrintExt = timerfactory.Create<Logistics.Vendor.ICheckAPVoucherPrint>(_CheckAPVoucherPrint);
			
			return iCheckAPVoucherPrintExt;
		}
	}
}
