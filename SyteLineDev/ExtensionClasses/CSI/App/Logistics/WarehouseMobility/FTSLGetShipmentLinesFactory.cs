//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetShipmentLinesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetShipmentLinesFactory
	{
		public IFTSLGetShipmentLines Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLGetShipmentLines = new Logistics.WarehouseMobility.FTSLGetShipmentLines(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetShipmentLinesExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetShipmentLines>(_FTSLGetShipmentLines);
			
			return iFTSLGetShipmentLinesExt;
		}
	}
}
