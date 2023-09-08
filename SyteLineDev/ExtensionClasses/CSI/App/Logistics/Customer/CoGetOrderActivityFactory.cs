//PROJECT NAME: Logistics
//CLASS NAME: CoGetOrderActivityFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoGetOrderActivityFactory
	{
		public ICoGetOrderActivity Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoGetOrderActivity = new Logistics.Customer.CoGetOrderActivity(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoGetOrderActivityExt = timerfactory.Create<Logistics.Customer.ICoGetOrderActivity>(_CoGetOrderActivity);
			
			return iCoGetOrderActivityExt;
		}
	}
}
