//PROJECT NAME: Logistics
//CLASS NAME: AptrxGetVoucherNoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AptrxGetVoucherNoFactory
	{
		public IAptrxGetVoucherNo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AptrxGetVoucherNo = new Logistics.Vendor.AptrxGetVoucherNo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAptrxGetVoucherNoExt = timerfactory.Create<Logistics.Vendor.IAptrxGetVoucherNo>(_AptrxGetVoucherNo);
			
			return iAptrxGetVoucherNoExt;
		}
	}
}
