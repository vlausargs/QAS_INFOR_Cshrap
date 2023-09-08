//PROJECT NAME: Logistics
//CLASS NAME: FTTAOrderDownloadFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTTAOrderDownloadFactory
	{
		public IFTTAOrderDownload Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTTAOrderDownload = new Logistics.WarehouseMobility.FTTAOrderDownload(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTTAOrderDownloadExt = timerfactory.Create<Logistics.WarehouseMobility.IFTTAOrderDownload>(_FTTAOrderDownload);
			
			return iFTTAOrderDownloadExt;
		}
	}
}
