//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeaveVendToPayAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeaveVendToPayAmtFactory
	{
		public IAppmtLeaveVendToPayAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtLeaveVendToPayAmt = new Logistics.Vendor.AppmtLeaveVendToPayAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtLeaveVendToPayAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtLeaveVendToPayAmt>(_AppmtLeaveVendToPayAmt);
			
			return iAppmtLeaveVendToPayAmtExt;
		}
	}
}
