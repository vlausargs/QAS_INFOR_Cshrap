//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetShipmentsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetShipmentsFactory
	{
		public IFTSLGetShipments Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLGetShipments = new Logistics.WarehouseMobility.FTSLGetShipments(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetShipmentsExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetShipments>(_FTSLGetShipments);
			
			return iFTSLGetShipmentsExt;
		}
	}
}
