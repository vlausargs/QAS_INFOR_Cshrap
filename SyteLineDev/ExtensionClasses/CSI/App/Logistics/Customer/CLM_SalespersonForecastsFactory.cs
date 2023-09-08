//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalespersonForecastsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SalespersonForecastsFactory
	{
		public ICLM_SalespersonForecasts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SalespersonForecasts = new Logistics.Customer.CLM_SalespersonForecasts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SalespersonForecastsExt = timerfactory.Create<Logistics.Customer.ICLM_SalespersonForecasts>(_CLM_SalespersonForecasts);
			
			return iCLM_SalespersonForecastsExt;
		}
	}
}
