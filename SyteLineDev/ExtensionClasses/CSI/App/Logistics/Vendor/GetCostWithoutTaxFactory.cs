//PROJECT NAME: Logistics
//CLASS NAME: GetCostWithoutTaxFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetCostWithoutTaxFactory
	{
		public IGetCostWithoutTax Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCostWithoutTax = new Logistics.Vendor.GetCostWithoutTax(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCostWithoutTaxExt = timerfactory.Create<Logistics.Vendor.IGetCostWithoutTax>(_GetCostWithoutTax);
			
			return iGetCostWithoutTaxExt;
		}
	}
}
