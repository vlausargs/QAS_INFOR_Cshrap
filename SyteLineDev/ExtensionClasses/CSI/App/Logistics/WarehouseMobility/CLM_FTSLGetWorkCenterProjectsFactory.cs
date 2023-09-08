//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetWorkCenterProjectsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetWorkCenterProjectsFactory
	{
		public ICLM_FTSLGetWorkCenterProjects Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetWorkCenterProjects = new Logistics.WarehouseMobility.CLM_FTSLGetWorkCenterProjects(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetWorkCenterProjectsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetWorkCenterProjects>(_CLM_FTSLGetWorkCenterProjects);
			
			return iCLM_FTSLGetWorkCenterProjectsExt;
		}
	}
}
