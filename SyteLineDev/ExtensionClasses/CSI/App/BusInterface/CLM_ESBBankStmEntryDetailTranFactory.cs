//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBankStmEntryDetailTranFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBBankStmEntryDetailTranFactory
	{
		public ICLM_ESBBankStmEntryDetailTran Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBBankStmEntryDetailTran = new BusInterface.CLM_ESBBankStmEntryDetailTran(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBBankStmEntryDetailTranExt = timerfactory.Create<BusInterface.ICLM_ESBBankStmEntryDetailTran>(_CLM_ESBBankStmEntryDetailTran);
			
			return iCLM_ESBBankStmEntryDetailTranExt;
		}
	}
}
