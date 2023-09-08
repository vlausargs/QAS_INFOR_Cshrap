//PROJECT NAME: Finance
//CLASS NAME: CLM_ExecutiveOppWonLostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_ExecutiveOppWonLostFactory
	{
		public ICLM_ExecutiveOppWonLost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ExecutiveOppWonLost = new Finance.CLM_ExecutiveOppWonLost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ExecutiveOppWonLostExt = timerfactory.Create<Finance.ICLM_ExecutiveOppWonLost>(_CLM_ExecutiveOppWonLost);
			
			return iCLM_ExecutiveOppWonLostExt;
		}
	}
}
