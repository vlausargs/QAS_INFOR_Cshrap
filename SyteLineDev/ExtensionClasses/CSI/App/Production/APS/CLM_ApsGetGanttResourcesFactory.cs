//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetGanttResourcesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetGanttResourcesFactory
	{
		public ICLM_ApsGetGanttResources Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetGanttResources = new Production.APS.CLM_ApsGetGanttResources(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetGanttResourcesExt = timerfactory.Create<Production.APS.ICLM_ApsGetGanttResources>(_CLM_ApsGetGanttResources);
			
			return iCLM_ApsGetGanttResourcesExt;
		}
	}
}
