//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReplDocumentExtFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReplDocumentExtFactory
	{
		public ICLM_ESBReplDocumentExt Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReplDocumentExt = new BusInterface.CLM_ESBReplDocumentExt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReplDocumentExtExt = timerfactory.Create<BusInterface.ICLM_ESBReplDocumentExt>(_CLM_ESBReplDocumentExt);
			
			return iCLM_ESBReplDocumentExtExt;
		}
	}
}
