//PROJECT NAME: Logistics
//CLASS NAME: EuroCustSitesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class EuroCustSitesFactory
	{
		public IEuroCustSites Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _EuroCustSites = new Logistics.Customer.EuroCustSites(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEuroCustSitesExt = timerfactory.Create<Logistics.Customer.IEuroCustSites>(_EuroCustSites);
			
			return iEuroCustSitesExt;
		}
	}
}
