//PROJECT NAME: Finance
//CLASS NAME: CLM_DunningCustHistoryFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_DunningCustHistoryFactory
	{
		public ICLM_DunningCustHistory Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DunningCustHistory = new Finance.CLM_DunningCustHistory(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DunningCustHistoryExt = timerfactory.Create<Finance.ICLM_DunningCustHistory>(_CLM_DunningCustHistory);
			
			return iCLM_DunningCustHistoryExt;
		}
	}
}
