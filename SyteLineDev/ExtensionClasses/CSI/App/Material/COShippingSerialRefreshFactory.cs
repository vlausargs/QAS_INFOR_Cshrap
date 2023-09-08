//PROJECT NAME: Material
//CLASS NAME: COShippingSerialRefreshFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class COShippingSerialRefreshFactory
	{
		public ICOShippingSerialRefresh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _COShippingSerialRefresh = new Material.COShippingSerialRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOShippingSerialRefreshExt = timerfactory.Create<Material.ICOShippingSerialRefresh>(_COShippingSerialRefresh);
			
			return iCOShippingSerialRefreshExt;
		}
	}
}
