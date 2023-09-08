//PROJECT NAME: Logistics
//CLASS NAME: ReserveOrderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class ReserveOrderFactory
	{
		public IReserveOrder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ReserveOrder = new Logistics.Customer.ReserveOrder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReserveOrderExt = timerfactory.Create<Logistics.Customer.IReserveOrder>(_ReserveOrder);
			
			return iReserveOrderExt;
		}
	}
}
