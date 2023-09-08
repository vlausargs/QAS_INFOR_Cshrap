//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCreditTransferFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCreditTransferFactory
	{
		public ICLM_ESBCreditTransfer Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCreditTransfer = new BusInterface.CLM_ESBCreditTransfer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCreditTransferExt = timerfactory.Create<BusInterface.ICLM_ESBCreditTransfer>(_CLM_ESBCreditTransfer);
			
			return iCLM_ESBCreditTransferExt;
		}
	}
}
