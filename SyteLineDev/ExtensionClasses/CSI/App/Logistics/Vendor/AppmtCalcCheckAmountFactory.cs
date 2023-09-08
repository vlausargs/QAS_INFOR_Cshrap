//PROJECT NAME: Logistics
//CLASS NAME: AppmtCalcCheckAmountFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtCalcCheckAmountFactory
	{
		public IAppmtCalcCheckAmount Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtCalcCheckAmount = new Logistics.Vendor.AppmtCalcCheckAmount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtCalcCheckAmountExt = timerfactory.Create<Logistics.Vendor.IAppmtCalcCheckAmount>(_AppmtCalcCheckAmount);
			
			return iAppmtCalcCheckAmountExt;
		}
	}
}
