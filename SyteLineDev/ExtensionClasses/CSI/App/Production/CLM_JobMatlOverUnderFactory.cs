//PROJECT NAME: Production
//CLASS NAME: CLM_JobMatlOverUnderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_JobMatlOverUnderFactory
	{
		public ICLM_JobMatlOverUnder Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_JobMatlOverUnder = new Production.CLM_JobMatlOverUnder(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_JobMatlOverUnderExt = timerfactory.Create<Production.ICLM_JobMatlOverUnder>(_CLM_JobMatlOverUnder);
			
			return iCLM_JobMatlOverUnderExt;
		}
	}
}
