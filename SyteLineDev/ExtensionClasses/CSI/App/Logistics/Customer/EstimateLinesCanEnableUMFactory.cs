//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesCanEnableUMFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesCanEnableUMFactory
	{
		public IEstimateLinesCanEnableUM Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EstimateLinesCanEnableUM = new Logistics.Customer.EstimateLinesCanEnableUM(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEstimateLinesCanEnableUMExt = timerfactory.Create<Logistics.Customer.IEstimateLinesCanEnableUM>(_EstimateLinesCanEnableUM);
			
			return iEstimateLinesCanEnableUMExt;
		}
	}
}
