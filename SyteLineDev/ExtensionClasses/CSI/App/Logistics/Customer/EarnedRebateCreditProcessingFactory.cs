//PROJECT NAME: Logistics
//CLASS NAME: EarnedRebateCreditProcessingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EarnedRebateCreditProcessingFactory
	{
		public IEarnedRebateCreditProcessing Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EarnedRebateCreditProcessing = new Logistics.Customer.EarnedRebateCreditProcessing(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEarnedRebateCreditProcessingExt = timerfactory.Create<Logistics.Customer.IEarnedRebateCreditProcessing>(_EarnedRebateCreditProcessing);
			
			return iEarnedRebateCreditProcessingExt;
		}
	}
}
