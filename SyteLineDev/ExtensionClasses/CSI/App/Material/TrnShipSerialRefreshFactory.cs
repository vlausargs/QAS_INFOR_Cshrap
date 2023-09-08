//PROJECT NAME: Material
//CLASS NAME: TrnShipSerialRefreshFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TrnShipSerialRefreshFactory
	{
		public ITrnShipSerialRefresh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TrnShipSerialRefresh = new Material.TrnShipSerialRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnShipSerialRefreshExt = timerfactory.Create<Material.ITrnShipSerialRefresh>(_TrnShipSerialRefresh);
			
			return iTrnShipSerialRefreshExt;
		}
	}
}
