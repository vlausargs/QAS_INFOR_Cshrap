//PROJECT NAME: Logistics
//CLASS NAME: FTSLTAGetResourceIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLTAGetResourceIdFactory
	{
		public IFTSLTAGetResourceId Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLTAGetResourceId = new Logistics.WarehouseMobility.FTSLTAGetResourceId(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLTAGetResourceIdExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLTAGetResourceId>(_FTSLTAGetResourceId);
			
			return iFTSLTAGetResourceIdExt;
		}
	}
}
