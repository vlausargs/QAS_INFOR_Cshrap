//PROJECT NAME: Logistics
//CLASS NAME: ChkPayFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class ChkPayFactory
	{
		public IChkPay Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ChkPay = new Logistics.Vendor.ChkPay(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iChkPayExt = timerfactory.Create<Logistics.Vendor.IChkPay>(_ChkPay);
			
			return iChkPayExt;
		}
	}
}
