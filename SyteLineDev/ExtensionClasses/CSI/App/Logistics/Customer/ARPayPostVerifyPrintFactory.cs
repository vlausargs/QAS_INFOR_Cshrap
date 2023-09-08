//PROJECT NAME: Logistics
//CLASS NAME: ARPayPostVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARPayPostVerifyPrintFactory
	{
		public IARPayPostVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARPayPostVerifyPrint = new Logistics.Customer.ARPayPostVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARPayPostVerifyPrintExt = timerfactory.Create<Logistics.Customer.IARPayPostVerifyPrint>(_ARPayPostVerifyPrint);
			
			return iARPayPostVerifyPrintExt;
		}
	}
}
