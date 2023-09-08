//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeavePayExchRateAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeavePayExchRateAmtFactory
	{
		public IAppmtLeavePayExchRateAmt Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _AppmtLeavePayExchRateAmt = new Logistics.Vendor.AppmtLeavePayExchRateAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtLeavePayExchRateAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtLeavePayExchRateAmt>(_AppmtLeavePayExchRateAmt);
			
			return iAppmtLeavePayExchRateAmtExt;
		}
	}
}
