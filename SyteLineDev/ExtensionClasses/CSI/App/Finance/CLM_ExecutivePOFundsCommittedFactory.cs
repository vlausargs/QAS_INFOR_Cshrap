//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutivePOFundsCommittedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutivePOFundsCommittedFactory
	{
		public ICLM_ExecutivePOFundsCommitted Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutivePOFundsCommitted = new Finance.CLM_ExecutivePOFundsCommitted(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutivePOFundsCommittedExt = timerfactory.Create<Finance.ICLM_ExecutivePOFundsCommitted>(_CLM_ExecutivePOFundsCommitted);
			
			return iCLM_ExecutivePOFundsCommittedExt;
		}
	}
}
