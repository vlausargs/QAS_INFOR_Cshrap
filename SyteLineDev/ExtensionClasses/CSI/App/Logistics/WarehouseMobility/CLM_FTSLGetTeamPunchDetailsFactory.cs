//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetTeamPunchDetailsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetTeamPunchDetailsFactory
	{
		public ICLM_FTSLGetTeamPunchDetails Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetTeamPunchDetails = new Logistics.WarehouseMobility.CLM_FTSLGetTeamPunchDetails(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetTeamPunchDetailsExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetTeamPunchDetails>(_CLM_FTSLGetTeamPunchDetails);
			
			return iCLM_FTSLGetTeamPunchDetailsExt;
		}
	}
}
