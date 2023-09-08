//PROJECT NAME: Logistics
//CLASS NAME: UpdateOrderExchRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdateOrderExchRateFactory
	{
		public IUpdateOrderExchRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateOrderExchRate = new Logistics.Customer.UpdateOrderExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateOrderExchRateExt = timerfactory.Create<Logistics.Customer.IUpdateOrderExchRate>(_UpdateOrderExchRate);
			
			return iUpdateOrderExchRateExt;
		}
	}
}
