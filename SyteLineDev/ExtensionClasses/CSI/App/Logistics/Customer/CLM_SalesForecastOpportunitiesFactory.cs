//PROJECT NAME: Logistics
//CLASS NAME: CLM_SalesForecastOpportunitiesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_SalesForecastOpportunitiesFactory
	{
		public ICLM_SalesForecastOpportunities Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SalesForecastOpportunities = new Logistics.Customer.CLM_SalesForecastOpportunities(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SalesForecastOpportunitiesExt = timerfactory.Create<Logistics.Customer.ICLM_SalesForecastOpportunities>(_CLM_SalesForecastOpportunities);
			
			return iCLM_SalesForecastOpportunitiesExt;
		}
	}
}
