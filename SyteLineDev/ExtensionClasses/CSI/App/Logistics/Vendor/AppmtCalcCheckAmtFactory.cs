//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcCheckAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcCheckAmtFactory
	{
		public IAppmtCalcCheckAmt Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtCalcCheckAmt = new Logistics.Vendor.AppmtCalcCheckAmt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtCalcCheckAmtExt = timerfactory.Create<Logistics.Vendor.IAppmtCalcCheckAmt>(_AppmtCalcCheckAmt);
			
			return iAppmtCalcCheckAmtExt;
		}
	}
}
