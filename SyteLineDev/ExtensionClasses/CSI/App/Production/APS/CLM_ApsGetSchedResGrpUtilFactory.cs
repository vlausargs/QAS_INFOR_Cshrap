//PROJECT NAME: Production
//CLASS NAME: CLM_ApsGetSchedResGrpUtilFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsGetSchedResGrpUtilFactory
	{
		public ICLM_ApsGetSchedResGrpUtil Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsGetSchedResGrpUtil = new Production.APS.CLM_ApsGetSchedResGrpUtil(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsGetSchedResGrpUtilExt = timerfactory.Create<Production.APS.ICLM_ApsGetSchedResGrpUtil>(_CLM_ApsGetSchedResGrpUtil);
			
			return iCLM_ApsGetSchedResGrpUtilExt;
		}
	}
}
