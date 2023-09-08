//PROJECT NAME: Logistics
//CLASS NAME: AppmtLeavePayToVendAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtLeavePayToVendAmtFactory
	{
		public IAppmtLeavePayToVendAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtLeavePayToVendAmt = new Logistics.Vendor.AppmtLeavePayToVendAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtLeavePayToVendAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtLeavePayToVendAmt>(_AppmtLeavePayToVendAmt);
			
			return iAppmtLeavePayToVendAmtExt;
		}
	}
}
