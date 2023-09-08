//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeaveVendAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeaveVendAmtFactory
	{
		public IAppmtLeaveVendAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtLeaveVendAmt = new Logistics.Vendor.AppmtLeaveVendAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtLeaveVendAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtLeaveVendAmt>(_AppmtLeaveVendAmt);
			
			return iAppmtLeaveVendAmtExt;
		}
	}
}
