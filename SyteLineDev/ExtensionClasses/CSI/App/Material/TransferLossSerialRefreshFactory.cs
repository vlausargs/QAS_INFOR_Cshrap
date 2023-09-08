//PROJECT NAME: Material
//CLASS NAME: TransferLossSerialRefreshFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class TransferLossSerialRefreshFactory
	{
		public ITransferLossSerialRefresh Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _TransferLossSerialRefresh = new Material.TransferLossSerialRefresh(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTransferLossSerialRefreshExt = timerfactory.Create<Material.ITransferLossSerialRefresh>(_TransferLossSerialRefresh);
			
			return iTransferLossSerialRefreshExt;
		}
	}
}
