//PROJECT NAME: CSIAPS
//CLASS NAME: CLM_SchedDemandSummariesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.APS
{
	public class CLM_SchedDemandSummariesFactory
	{
		public ICLM_SchedDemandSummaries Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SchedDemandSummaries = new Production.APS.CLM_SchedDemandSummaries(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SchedDemandSummariesExt = timerfactory.Create<Production.APS.ICLM_SchedDemandSummaries>(_CLM_SchedDemandSummaries);
			
			return iCLM_SchedDemandSummariesExt;
		}
	}
}
