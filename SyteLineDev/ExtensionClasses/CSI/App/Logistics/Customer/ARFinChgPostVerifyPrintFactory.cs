//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostVerifyPrintFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostVerifyPrintFactory
	{
		public IARFinChgPostVerifyPrint Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARFinChgPostVerifyPrint = new Logistics.Customer.ARFinChgPostVerifyPrint(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinChgPostVerifyPrintExt = timerfactory.Create<Logistics.Customer.IARFinChgPostVerifyPrint>(_ARFinChgPostVerifyPrint);
			
			return iARFinChgPostVerifyPrintExt;
		}
	}
}
