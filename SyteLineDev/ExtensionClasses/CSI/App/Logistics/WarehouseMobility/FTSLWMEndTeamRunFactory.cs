//PROJECT NAME: Logistics
//CLASS NAME: FTSLWMEndTeamRunFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLWMEndTeamRunFactory
	{
		public IFTSLWMEndTeamRun Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLWMEndTeamRun = new Logistics.WarehouseMobility.FTSLWMEndTeamRun(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLWMEndTeamRunExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLWMEndTeamRun>(_FTSLWMEndTeamRun);
			
			return iFTSLWMEndTeamRunExt;
		}
	}
}
