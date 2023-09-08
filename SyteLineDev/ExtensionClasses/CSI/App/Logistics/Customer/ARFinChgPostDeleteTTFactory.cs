//PROJECT NAME: Logistics
//CLASS NAME: ARFinChgPostDeleteTTFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ARFinChgPostDeleteTTFactory
	{
		public IARFinChgPostDeleteTT Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ARFinChgPostDeleteTT = new Logistics.Customer.ARFinChgPostDeleteTT(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARFinChgPostDeleteTTExt = timerfactory.Create<Logistics.Customer.IARFinChgPostDeleteTT>(_ARFinChgPostDeleteTT);
			
			return iARFinChgPostDeleteTTExt;
		}
	}
}
