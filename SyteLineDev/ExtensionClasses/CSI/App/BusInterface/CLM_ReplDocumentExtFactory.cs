//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ReplDocumentExtFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ReplDocumentExtFactory
	{
		public ICLM_ReplDocumentExt Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ReplDocumentExt = new BusInterface.CLM_ReplDocumentExt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ReplDocumentExtExt = timerfactory.Create<BusInterface.ICLM_ReplDocumentExt>(_CLM_ReplDocumentExt);
			
			return iCLM_ReplDocumentExtExt;
		}
	}
}
