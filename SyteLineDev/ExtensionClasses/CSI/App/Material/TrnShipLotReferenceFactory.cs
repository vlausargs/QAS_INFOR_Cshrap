//PROJECT NAME: Material
//CLASS NAME: TrnShipLotReferenceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TrnShipLotReferenceFactory
	{
		public ITrnShipLotReference Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TrnShipLotReference = new Material.TrnShipLotReference(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrnShipLotReferenceExt = timerfactory.Create<Material.ITrnShipLotReference>(_TrnShipLotReference);
			
			return iTrnShipLotReferenceExt;
		}
	}
}
