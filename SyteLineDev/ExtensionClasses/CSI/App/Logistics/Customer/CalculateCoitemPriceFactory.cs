//PROJECT NAME: Logistics
//CLASS NAME: CalculateCoitemPriceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CalculateCoitemPriceFactory
	{
		public ICalculateCoitemPrice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalculateCoitemPrice = new Logistics.Customer.CalculateCoitemPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalculateCoitemPriceExt = timerfactory.Create<Logistics.Customer.ICalculateCoitemPrice>(_CalculateCoitemPrice);
			
			return iCalculateCoitemPriceExt;
		}
	}
}
