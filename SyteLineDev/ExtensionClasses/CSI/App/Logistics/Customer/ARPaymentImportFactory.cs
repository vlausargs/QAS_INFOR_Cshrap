//PROJECT NAME: Logistics
//CLASS NAME: ARPaymentImportFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPaymentImportFactory
	{
		public IARPaymentImport Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPaymentImport = new Logistics.Customer.ARPaymentImport(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPaymentImportExt = timerfactory.Create<Logistics.Customer.IARPaymentImport>(_ARPaymentImport);
			
			return iARPaymentImportExt;
		}
	}
}
