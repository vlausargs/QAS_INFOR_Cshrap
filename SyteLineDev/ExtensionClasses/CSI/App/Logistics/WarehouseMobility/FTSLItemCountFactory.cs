//PROJECT NAME: Logistics
//CLASS NAME: FTSLItemCountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLItemCountFactory
	{
		public IFTSLItemCount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLItemCount = new Logistics.WarehouseMobility.FTSLItemCount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLItemCountExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLItemCount>(_FTSLItemCount);
			
			return iFTSLItemCountExt;
		}
	}
}
