//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBChartOfAccountsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBChartOfAccountsFactory
	{
		public ICLM_ESBChartOfAccounts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBChartOfAccounts = new BusInterface.CLM_ESBChartOfAccounts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBChartOfAccountsExt = timerfactory.Create<BusInterface.ICLM_ESBChartOfAccounts>(_CLM_ESBChartOfAccounts);
			
			return iCLM_ESBChartOfAccountsExt;
		}
	}
}
