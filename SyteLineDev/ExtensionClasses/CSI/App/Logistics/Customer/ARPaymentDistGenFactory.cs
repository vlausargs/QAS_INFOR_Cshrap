//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentDistGenFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentDistGenFactory
	{
		public IARPaymentDistGen Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentDistGen = new Logistics.Customer.ARPaymentDistGen(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentDistGenExt = timerfactory.Create<Logistics.Customer.IARPaymentDistGen>(_ARPaymentDistGen);
			
			return iARPaymentDistGenExt;
		}
	}
}
