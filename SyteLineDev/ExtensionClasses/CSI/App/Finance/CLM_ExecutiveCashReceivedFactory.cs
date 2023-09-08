//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveCashReceivedFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveCashReceivedFactory
	{
		public ICLM_ExecutiveCashReceived Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveCashReceived = new Finance.CLM_ExecutiveCashReceived(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveCashReceivedExt = timerfactory.Create<Finance.ICLM_ExecutiveCashReceived>(_CLM_ExecutiveCashReceived);
			
			return iCLM_ExecutiveCashReceivedExt;
		}
	}
}
