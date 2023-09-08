//PROJECT NAME: Production
//CLASS NAME: Home_ApsGetDemandSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class Home_ApsGetDemandSummaryFactory
	{
		public IHome_ApsGetDemandSummary Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_ApsGetDemandSummary = new Production.APS.Home_ApsGetDemandSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_ApsGetDemandSummaryExt = timerfactory.Create<Production.APS.IHome_ApsGetDemandSummary>(_Home_ApsGetDemandSummary);
			
			return iHome_ApsGetDemandSummaryExt;
		}
	}
}
