//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentPostingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentPostingFactory
	{
		public IARPaymentPosting Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentPosting = new Logistics.Customer.ARPaymentPosting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentPostingExt = timerfactory.Create<Logistics.Customer.IARPaymentPosting>(_ARPaymentPosting);
			
			return iARPaymentPostingExt;
		}
	}
}
