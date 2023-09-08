//PROJECT NAME: Production
//CLASS NAME: Home_ResourcePlanFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class Home_ResourcePlanFactory
	{
		public IHome_ResourcePlan Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Home_ResourcePlan = new Production.APS.Home_ResourcePlan(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHome_ResourcePlanExt = timerfactory.Create<Production.APS.IHome_ResourcePlan>(_Home_ResourcePlan);
			
			return iHome_ResourcePlanExt;
		}
	}
}
