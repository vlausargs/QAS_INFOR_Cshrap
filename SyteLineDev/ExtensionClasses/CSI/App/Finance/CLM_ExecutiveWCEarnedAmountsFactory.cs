//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveWCEarnedAmountsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveWCEarnedAmountsFactory
	{
		public ICLM_ExecutiveWCEarnedAmounts Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveWCEarnedAmounts = new Finance.CLM_ExecutiveWCEarnedAmounts(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveWCEarnedAmountsExt = timerfactory.Create<Finance.ICLM_ExecutiveWCEarnedAmounts>(_CLM_ExecutiveWCEarnedAmounts);
			
			return iCLM_ExecutiveWCEarnedAmountsExt;
		}
	}
}
