//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetPOPreAssignedSerialsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetPOPreAssignedSerialsFactory
	{
		public IFTSLGetPOPreAssignedSerials Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLGetPOPreAssignedSerials = new Logistics.WarehouseMobility.FTSLGetPOPreAssignedSerials(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetPOPreAssignedSerialsExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetPOPreAssignedSerials>(_FTSLGetPOPreAssignedSerials);
			
			return iFTSLGetPOPreAssignedSerialsExt;
		}
	}
}
