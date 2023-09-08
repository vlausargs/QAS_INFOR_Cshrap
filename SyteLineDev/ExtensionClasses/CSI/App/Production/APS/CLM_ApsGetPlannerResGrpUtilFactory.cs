//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetPlannerResGrpUtilFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetPlannerResGrpUtilFactory
	{
		public ICLM_ApsGetPlannerResGrpUtil Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetPlannerResGrpUtil = new Production.APS.CLM_ApsGetPlannerResGrpUtil(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetPlannerResGrpUtilExt = timerfactory.Create<Production.APS.ICLM_ApsGetPlannerResGrpUtil>(_CLM_ApsGetPlannerResGrpUtil);
			
			return iCLM_ApsGetPlannerResGrpUtilExt;
		}
	}
}
