//PROJECT NAME: Logistics
//CLASS NAME: AppmtGetAmtsAppliedFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AppmtGetAmtsAppliedFactory
	{
		public IAppmtGetAmtsApplied Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AppmtGetAmtsApplied = new Logistics.Vendor.AppmtGetAmtsApplied(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAppmtGetAmtsAppliedExt = timerfactory.Create<Logistics.Vendor.IAppmtGetAmtsApplied>(_AppmtGetAmtsApplied);
			
			return iAppmtGetAmtsAppliedExt;
		}
	}
}
