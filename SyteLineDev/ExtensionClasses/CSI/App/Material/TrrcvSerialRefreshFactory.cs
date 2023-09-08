//PROJECT NAME: Material
//CLASS NAME: TrrcvSerialRefreshFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TrrcvSerialRefreshFactory
	{
		public ITrrcvSerialRefresh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TrrcvSerialRefresh = new Material.TrrcvSerialRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTrrcvSerialRefreshExt = timerfactory.Create<Material.ITrrcvSerialRefresh>(_TrrcvSerialRefresh);
			
			return iTrrcvSerialRefreshExt;
		}
	}
}
