//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceivableTransactionHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceivableTransactionHdrFactory
	{
		public ICLM_ESBReceivableTransactionHdr Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceivableTransactionHdr = new BusInterface.CLM_ESBReceivableTransactionHdr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceivableTransactionHdrExt = timerfactory.Create<BusInterface.ICLM_ESBReceivableTransactionHdr>(_CLM_ESBReceivableTransactionHdr);
			
			return iCLM_ESBReceivableTransactionHdrExt;
		}
	}
}
