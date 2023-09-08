//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentDistPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentDistPostingFactory
	{
		public IARPaymentDistPosting Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentDistPosting = new Logistics.Customer.ARPaymentDistPosting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentDistPostingExt = timerfactory.Create<Logistics.Customer.IARPaymentDistPosting>(_ARPaymentDistPosting);
			
			return iARPaymentDistPostingExt;
		}
	}
}
