//PROJECT NAME: Material
//CLASS NAME: CombineXferSerialRefreshFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CombineXferSerialRefreshFactory
	{
		public ICombineXferSerialRefresh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CombineXferSerialRefresh = new Material.CombineXferSerialRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferSerialRefreshExt = timerfactory.Create<Material.ICombineXferSerialRefresh>(_CombineXferSerialRefresh);
			
			return iCombineXferSerialRefreshExt;
		}
	}
}
