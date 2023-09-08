//PROJECT NAME: Logistics
//CLASS NAME: EDICalculateCoitemPriceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EDICalculateCoitemPriceFactory
	{
		public IEDICalculateCoitemPrice Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EDICalculateCoitemPrice = new Logistics.Customer.EDICalculateCoitemPrice(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEDICalculateCoitemPriceExt = timerfactory.Create<Logistics.Customer.IEDICalculateCoitemPrice>(_EDICalculateCoitemPrice);
			
			return iEDICalculateCoitemPriceExt;
		}
	}
}
