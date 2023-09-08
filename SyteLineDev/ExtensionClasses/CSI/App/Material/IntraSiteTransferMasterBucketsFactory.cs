//PROJECT NAME: Material
//CLASS NAME: IntraSiteTransferMasterBucketsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class IntraSiteTransferMasterBucketsFactory
	{
		public IIntraSiteTransferMasterBuckets Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _IntraSiteTransferMasterBuckets = new Material.IntraSiteTransferMasterBuckets(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIntraSiteTransferMasterBucketsExt = timerfactory.Create<Material.IIntraSiteTransferMasterBuckets>(_IntraSiteTransferMasterBuckets);
			
			return iIntraSiteTransferMasterBucketsExt;
		}
	}
}
