//PROJECT NAME: BusInterface
//CLASS NAME: ReplDocumentExtListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class ReplDocumentExtListFactory
	{
		public IReplDocumentExtList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ReplDocumentExtList = new BusInterface.ReplDocumentExtList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iReplDocumentExtListExt = timerfactory.Create<BusInterface.IReplDocumentExtList>(_ReplDocumentExtList);
			
			return iReplDocumentExtListExt;
		}
	}
}
