//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentPostingCleanupFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentPostingCleanupFactory
	{
		public IARPaymentPostingCleanup Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentPostingCleanup = new Logistics.Customer.ARPaymentPostingCleanup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentPostingCleanupExt = timerfactory.Create<Logistics.Customer.IARPaymentPostingCleanup>(_ARPaymentPostingCleanup);
			
			return iARPaymentPostingCleanupExt;
		}
	}
}
