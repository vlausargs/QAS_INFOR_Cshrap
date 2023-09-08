//PROJECT NAME: Logistics
//CLASS NAME: AU_RepricePoitemorBlanketLinesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class AU_RepricePoitemorBlanketLinesFactory
	{
		public IAU_RepricePoitemorBlanketLines Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AU_RepricePoitemorBlanketLines = new Logistics.Vendor.AU_RepricePoitemorBlanketLines(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAU_RepricePoitemorBlanketLinesExt = timerfactory.Create<Logistics.Vendor.IAU_RepricePoitemorBlanketLines>(_AU_RepricePoitemorBlanketLines);
			
			return iAU_RepricePoitemorBlanketLinesExt;
		}
	}
}
