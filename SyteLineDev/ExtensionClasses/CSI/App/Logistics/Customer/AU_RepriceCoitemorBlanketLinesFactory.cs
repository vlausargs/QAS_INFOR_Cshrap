//PROJECT NAME: Logistics
//CLASS NAME: AU_RepriceCoitemorBlanketLinesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class AU_RepriceCoitemorBlanketLinesFactory
	{
		public IAU_RepriceCoitemorBlanketLines Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AU_RepriceCoitemorBlanketLines = new Logistics.Customer.AU_RepriceCoitemorBlanketLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_RepriceCoitemorBlanketLinesExt = timerfactory.Create<Logistics.Customer.IAU_RepriceCoitemorBlanketLines>(_AU_RepriceCoitemorBlanketLines);
			
			return iAU_RepriceCoitemorBlanketLinesExt;
		}
	}
}
