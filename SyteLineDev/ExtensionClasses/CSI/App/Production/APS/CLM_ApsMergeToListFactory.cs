//PROJECT NAME: Production
//CLASS NAME: CLM_ApsMergeToListFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_ApsMergeToListFactory
	{
		public ICLM_ApsMergeToList Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ApsMergeToList = new Production.APS.CLM_ApsMergeToList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ApsMergeToListExt = timerfactory.Create<Production.APS.ICLM_ApsMergeToList>(_CLM_ApsMergeToList);
			
			return iCLM_ApsMergeToListExt;
		}
	}
}
