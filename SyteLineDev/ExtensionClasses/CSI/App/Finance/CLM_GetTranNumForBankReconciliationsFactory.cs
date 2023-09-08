//PROJECT NAME: Finance
//CLASS NAME: CLM_GetTranNumForBankReconciliationsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_GetTranNumForBankReconciliationsFactory
	{
		public ICLM_GetTranNumForBankReconciliations Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetTranNumForBankReconciliations = new Finance.CLM_GetTranNumForBankReconciliations(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetTranNumForBankReconciliationsExt = timerfactory.Create<Finance.ICLM_GetTranNumForBankReconciliations>(_CLM_GetTranNumForBankReconciliations);
			
			return iCLM_GetTranNumForBankReconciliationsExt;
		}
	}
}
