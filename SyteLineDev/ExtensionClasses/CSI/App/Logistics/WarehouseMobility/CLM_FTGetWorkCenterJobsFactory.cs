//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTGetWorkCenterJobsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTGetWorkCenterJobsFactory
	{
		public ICLM_FTGetWorkCenterJobs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTGetWorkCenterJobs = new Logistics.WarehouseMobility.CLM_FTGetWorkCenterJobs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTGetWorkCenterJobsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTGetWorkCenterJobs>(_CLM_FTGetWorkCenterJobs);
			
			return iCLM_FTGetWorkCenterJobsExt;
		}
	}
}
