//PROJECT NAME: Finance
//CLASS NAME: CLM_DunningSchedFieldValueFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_DunningSchedFieldValueFactory
	{
		public ICLM_DunningSchedFieldValue Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_DunningSchedFieldValue = new Finance.CLM_DunningSchedFieldValue(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_DunningSchedFieldValueExt = timerfactory.Create<Finance.ICLM_DunningSchedFieldValue>(_CLM_DunningSchedFieldValue);
			
			return iCLM_DunningSchedFieldValueExt;
		}
	}
}
