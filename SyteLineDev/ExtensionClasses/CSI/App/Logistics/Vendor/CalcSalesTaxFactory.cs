//PROJECT NAME: Logistics
//CLASS NAME: CalcSalesTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CalcSalesTaxFactory
	{
		public ICalcSalesTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalcSalesTax = new Logistics.Vendor.CalcSalesTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalcSalesTaxExt = timerfactory.Create<Logistics.Vendor.ICalcSalesTax>(_CalcSalesTax);
			
			return iCalcSalesTaxExt;
		}
	}
}
