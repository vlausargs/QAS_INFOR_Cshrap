//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_BatchSummaryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_BatchSummaryFactory
	{
		public ICLM_BatchSummary Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_BatchSummary = new Production.CLM_BatchSummary(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_BatchSummaryExt = timerfactory.Create<Production.ICLM_BatchSummary>(_CLM_BatchSummary);
			
			return iCLM_BatchSummaryExt;
		}
	}
}
