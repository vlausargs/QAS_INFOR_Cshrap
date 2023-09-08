//PROJECT NAME: Logistics
//CLASS NAME: EDICustBOrderItemUMFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EDICustBOrderItemUMFactory
	{
		public IEDICustBOrderItemUM Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EDICustBOrderItemUM = new Logistics.Customer.EDICustBOrderItemUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEDICustBOrderItemUMExt = timerfactory.Create<Logistics.Customer.IEDICustBOrderItemUM>(_EDICustBOrderItemUM);
			
			return iEDICustBOrderItemUMExt;
		}
	}
}
