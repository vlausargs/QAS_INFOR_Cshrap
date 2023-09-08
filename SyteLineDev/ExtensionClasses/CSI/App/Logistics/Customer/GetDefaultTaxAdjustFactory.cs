//PROJECT NAME: Logistics
//CLASS NAME: GetDefaultTaxAdjustFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetDefaultTaxAdjustFactory
	{
		public IGetDefaultTaxAdjust Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDefaultTaxAdjust = new Logistics.Customer.GetDefaultTaxAdjust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDefaultTaxAdjustExt = timerfactory.Create<Logistics.Customer.IGetDefaultTaxAdjust>(_GetDefaultTaxAdjust);
			
			return iGetDefaultTaxAdjustExt;
		}
	}
}
